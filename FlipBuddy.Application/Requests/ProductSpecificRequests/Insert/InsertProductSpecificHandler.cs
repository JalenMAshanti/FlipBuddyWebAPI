using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificRequests;

namespace FlipBuddy.Application.Requests.ProductSpecificRequests.Insert
{
	internal class InsertProductSpecificHandler : DataRequestHandler<InsertProductSpecificRequest>
	{
		public InsertProductSpecificHandler(IDataAccess dataAccess) : base(dataAccess)
		{
		}

		public async override Task ExecuteRequestAsync(InsertProductSpecificRequest request)
		{
			try
			{
				var rowaffected = await _dataAccess.ExecuteAsync(new InsertProductSpecific(request.ProductGuid, request.SpecificName!));

				if (rowaffected != 1) 
				{
					throw new OperationFailedException();
				}
			}
			catch (Exception ex)
			{
				throw new OperationFailedException();
			}
		}
	}
}
