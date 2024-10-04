using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Application.Helpers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Domain.Models;
using FlipBuddy.Domain.Models.APIResponses;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Persistence.Implementation;

namespace FlipBuddy.Application.Requests.ProductRequests.Upload
{
	internal class InsertProductByBarcodeHandler : DataRequestHandlerAPIService<InsertProductByBarcodeRequest>
	{
		public InsertProductByBarcodeHandler(IDataAccess dataAccess, ExternalAPIService externalAPIService) : base(dataAccess, externalAPIService)
		{
		}

		public async override Task ExecuteRequestAsync(InsertProductByBarcodeRequest request)
		{
			try
			{
				var userDTO = await _dataAccess.FetchAsync(new GetUserByGuid(request.UserGuid));

				if (userDTO == null)
				{
					throw new DoesNotExistException(nameof(User), (request.UserGuid, nameof(request.UserGuid)));
				}
				
				var upc = BarcodeScanner.ReadBarcode(request.Image!);

				var product = await _externalAPIService.GetAPIResponse<UpciteLookupAPIResponse>($"https://api.upcitemdb.com/prod/trial/lookup?upc={upc}");

				if (product.items == null)
				{
					throw new OperationFailedException();
				}

				await _dataAccess.ExecuteAsync(new InsertProduct(
																Guid.NewGuid(),
																request.UserGuid,
																product.items[0].title!,
																1,
																product.items[0].offers[0].price,
																product.items[0].highest_recorded_price,
																product.items[0].description!,
																1,
																product.items[0].currency!,
																0,
																upc
																));


			}
			catch (DataAccessException ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
