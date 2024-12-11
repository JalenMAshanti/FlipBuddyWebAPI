using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlippBuddy.Domain.Models;

namespace FlipBuddy.Application.Requests.ProductRequests.Delete
{
    internal class DeleteProductByProductGuidHandler : DataRequestHandler<DeleteProductByProductGuidRequest>
    {
        public DeleteProductByProductGuidHandler(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public override async Task ExecuteRequestAsync(DeleteProductByProductGuidRequest request)
        {
            try
            {
                var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteProductByGuid(request.ProductGuid));

                if (rowsAffected <= 0)
                {
                    throw new DoesNotExistException(nameof(Product), (request.ProductGuid, nameof(request.ProductGuid)));
                }
            }
            catch
            {
                throw new OperationFailedException();
            }
        }
    }
}
