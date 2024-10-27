using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificRequests;

namespace FlipBuddy.Application.Requests.ProductSpecificRequests.Delete
{
	internal class DeleteProductSpecificHandler : DataRequestHandler<DeleteProductSpecificRequest>
	{
		public DeleteProductSpecificHandler(IDataAccess dataAccess) : base(dataAccess)
		{
		}

		public override async Task ExecuteRequestAsync(DeleteProductSpecificRequest request)
		{
			try
			{
				var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteProductSpecific(request.SpecificId, request.ProductGuid));

				if (rowsAffected != 1) 
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
