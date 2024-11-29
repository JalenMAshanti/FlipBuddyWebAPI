using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Domain.Models;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificRequests;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificValueRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;

namespace FlipBuddy.Application.Requests.ProductRequests.Insert
{
	internal class InsertProductHandler : DataRequestHandler<InsertProductRequest>
	{
		public InsertProductHandler(IDataAccess dataAccess) : base(dataAccess)
		{
		}

		public override async Task ExecuteRequestAsync(InsertProductRequest request)
		{
			try
			{
				var userDTO = await _dataAccess.FetchAsync(new GetUserByGuid(request.UserGuid));

				if (userDTO == null)
				{
					throw new DoesNotExistException(nameof(User), (request.UserGuid, nameof(request.UserGuid)));
				}
				else
				{
					await _dataAccess.ExecuteAsync(new InsertProduct(request.Guid,
																	  request.UserGuid,
																	  request.Title!,
																	  request.CategoryId,
																	  request.PurchasedPrice,
																	  request.SellPrice,
																	  request.Description!,
																	  request.Quantity,
																	  request.Currency!,
																	  request.ConditionId,
																	  request.BarCode
																	));

					if (request.Specifics != null && request.Specifics.Any())
					{
						foreach (var specific in request.Specifics)
						{
							var nameCount = await _dataAccess.ExecuteAsync(new InsertProductSpecific(request.Guid, specific.SpecificName));

							if (nameCount != 1)
							{
								throw new OperationFailedException();
							}

							var productSpecifics = await _dataAccess.FetchListAsync(new GetProductSpecifics(request.Guid));
							var insertedSpecific = productSpecifics.Where(_ => _.SpecificName == specific.SpecificName).First();

							foreach (var value in specific.SpecificValues)
							{
								int valueCount = await _dataAccess.ExecuteAsync(new InsertProductSpecificValue(insertedSpecific.SpecificId, value.SpecificValue));

								if (valueCount != 1)
								{
									throw new OperationFailedException();
								}
							}
						}
					}
				}
			}
			catch (DataAccessException ex)
			{
				throw new OperationFailedException();
			}
		}
	}
}
