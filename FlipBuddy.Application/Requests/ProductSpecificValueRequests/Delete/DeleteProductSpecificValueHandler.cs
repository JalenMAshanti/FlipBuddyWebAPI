using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificValueRequests;

namespace FlipBuddy.Application.Requests.ProductSpecificValuesRequests.Delete
{
    internal class DeleteProductSpecificValueHandler : DataRequestHandler<DeleteProductSpecificValueRequest>
    {
        public DeleteProductSpecificValueHandler(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public async override Task ExecuteRequestAsync(DeleteProductSpecificValueRequest request)
        {
            try
            {
                var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteProductSpecificValue(request.ValueId, request.SpecificId));

                if (rowsAffected != 1) 
                {
                    throw new OperationFailedException();
                } 
            }
            catch(DataAccessException ex)
            {
                throw new OperationFailedException();
            }
        }
    }
}
