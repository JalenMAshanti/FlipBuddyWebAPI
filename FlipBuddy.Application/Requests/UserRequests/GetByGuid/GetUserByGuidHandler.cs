using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Domain.Models;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;

namespace FlipBuddy.Application.Requests.UserRequests.GetByGuid
{
	internal class GetUserByGuidHandler : DataRequestResponseHandler<GetUserByGuidRequest, GetUserByGuidResponse>
	{
		public GetUserByGuidHandler(IDataAccess dataAccess) : base(dataAccess) { }

		public override async Task<GetUserByGuidResponse> GetResponseAsync(GetUserByGuidRequest request)
		{
			var userDTO = await _dataAccess.FetchAsync(new GetUserByGuid(request.UserGuid));

			if (userDTO == null) 
			{
				throw new DoesNotExistException(nameof(User), (request.UserGuid, nameof(request.UserGuid)));
			}

			return new GetUserByGuidResponse(userDTO.AsDomainUser());
		}
	}
}
