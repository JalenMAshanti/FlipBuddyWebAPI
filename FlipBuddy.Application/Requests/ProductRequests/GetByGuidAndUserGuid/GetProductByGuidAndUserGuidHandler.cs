using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Domain.Models;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificRequests;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificValueRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlippBuddy.Domain.Models;

namespace FlipBuddy.Application.Requests.ProductRequests.GetByGuidAndUserGuid
{
	internal class GetProductByGuidAndUserGuidHandler : DataRequestResponseHandler<GetProductByGuidAndUserGuidRequest, GetProductByGuidAndUserGuidResponse>
	{
		public GetProductByGuidAndUserGuidHandler(IDataAccess dataAccess) : base(dataAccess)
		{
		}

		public async override Task<GetProductByGuidAndUserGuidResponse> GetResponseAsync(GetProductByGuidAndUserGuidRequest request)
		{
			try
			{
				//Get User
				var userDTO = await _dataAccess.FetchAsync(new GetUserByGuid(request.UserGuid));
				
				//Check if User Exists
				if (userDTO == null)
				{
					throw new DoesNotExistException(nameof(User), (request.UserGuid, nameof(request.UserGuid)));
				}

				//Get Product
				var productDTO = await _dataAccess.FetchAsync(new GetProductByGuidAndUserGuid(request.UserGuid, request.Guid));

				//Check if Product Exists
				if (productDTO == null)
				{
					throw new DoesNotExistException(nameof(Product), (request.Guid, nameof(request.Guid)));
				}

				//Get Product Specifics
				var productSpecificsDTO = await _dataAccess.FetchListAsync(new GetProductSpecifics(productDTO.Guid));
				
				if (productSpecificsDTO == null) 
				{
					return new GetProductByGuidAndUserGuidResponse(productDTO.AsDomainProduct());
				}

				#region HandleProductSpecifics

				GetProductByGuidAndUserGuidResponse response = new GetProductByGuidAndUserGuidResponse(productDTO.AsDomainProduct());

				response.ProductSpecifics = new List<ProductSpecificsAndSpecificValues>();

				foreach (var specific in productSpecificsDTO) 
				{
					var valuesDTO = await _dataAccess.FetchListAsync(new GetProductSpecificValuesBySpecificId(specific.SpecificId));

					List<ProductSpecificValue> specifics = new List<ProductSpecificValue>();
					
					foreach (var value in valuesDTO) 
					{
						specifics.Add(value.AsDomainProductSpecificValue());
					}


					response.ProductSpecifics.Add(new ProductSpecificsAndSpecificValues(specific.SpecificId, specific.SpecificName, specifics));				}

				return response;

				//if (productDTO != null)
				//{
				//	return new GetProductByGuidAndUserGuidResponse(productDTO.AsDomainProduct());
				//}		
				#endregion
			}
			catch 
			{
                throw new OperationFailedException();
            }
		}
	}
}
