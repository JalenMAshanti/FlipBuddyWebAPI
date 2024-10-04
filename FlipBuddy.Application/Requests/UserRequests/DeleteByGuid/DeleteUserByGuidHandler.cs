using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Domain.Models;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;

namespace FlipBuddy.Application.Requests.UserRequests.DeleteByGuid
{
	internal class DeleteUserByGuidHandler : DataRequestHandler<DeleteUserByGuidRequest>
	{
		public DeleteUserByGuidHandler(IDataAccess dataAccess) : base(dataAccess) { }

		public override async Task ExecuteRequestAsync(DeleteUserByGuidRequest request)
		{
			var userDTO = await _dataAccess.FetchAsync(new GetUserByGuid(request.UserGuid));
			
			if (userDTO == null) 
			{
				throw new DoesNotExistException(nameof(User), (request.UserGuid, nameof(request.UserGuid)));
			}

			var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteUserByGuid(request.UserGuid));

			if (rowsAffected <=0) 
			{
				throw new OperationFailedException();
			}
		}
	}
}
