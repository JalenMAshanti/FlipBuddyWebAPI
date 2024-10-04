using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Domain.Models;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
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
					await _dataAccess.ExecuteAsync(new InsertProduct( request.Guid,
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
				}
			}
			catch (DataAccessException ex) 
			{
				throw new OperationFailedException();
			}
		}
	}
}
