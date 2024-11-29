using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificValueRequests;

namespace FlipBuddy.Application.Requests.ProductSpecificValueRequests.Insert
{
    internal class InsertProductSpecificValueHandler : DataRequestHandler<InsertProductSpecificValueRequest>
    {
        public InsertProductSpecificValueHandler(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public override async Task ExecuteRequestAsync(InsertProductSpecificValueRequest request)
        {
            try 
            {
               var rowsAffected = await _dataAccess.ExecuteAsync(new InsertProductSpecificValue(request.SpecificId, request.SpecificValue));

                if (rowsAffected != 0) 
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
