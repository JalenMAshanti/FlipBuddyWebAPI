using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Domain.Models;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlippBuddy.Domain.Models;

namespace FlipBuddy.Application.Requests.ProductRequests.Update
{
    internal class UpdateProductByGuidAndUserGuidHandler : DataRequestHandler<UpdateProductByGuidAndUserGuidRequest>
    {
        public UpdateProductByGuidAndUserGuidHandler(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public override async Task ExecuteRequestAsync(UpdateProductByGuidAndUserGuidRequest request)
        {
            var user_DTO = _dataAccess.FetchAsync(new GetUserByGuid(request.Guid));

            if (user_DTO == null)
            {
                throw new DoesNotExistException(nameof(User), (request.UserGuid, nameof(request.UserGuid)));
            }

            var product_DTO = _dataAccess.FetchAsync(new GetProductByGuidAndUserGuid(request.UserGuid, request.Guid));

            if (product_DTO == null)
            {
                throw new DoesNotExistException(nameof(Product), (request.Guid, nameof(request.Guid)));
            }

            await _dataAccess.ExecuteAsync(new UpdateProductByGuidAndUserGuid(  request.Guid, 
                                                                                request.UserGuid, 
                                                                                request.Title, 
                                                                                request.CategoryId, 
                                                                                request.PurchasedPrice, 
                                                                                request.SellPrice, 
                                                                                request.Description, 
                                                                                request.Quantity, 
                                                                                request.Currency, 
                                                                                request.ConditionId, 
                                                                                request.BarCode, 
                                                                                request.DateSold));
        }
    }
}
