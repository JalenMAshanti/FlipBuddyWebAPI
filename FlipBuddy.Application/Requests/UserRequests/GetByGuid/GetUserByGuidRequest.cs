using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.BaseObjects.BaseRequests;

namespace FlipBuddy.Application.Requests.UserRequests.GetByGuid
{
	public class GetUserByGuidRequest : RequiredUserGuidRequest, IRequestResponse<GetUserByGuidResponse> 
	{
		public GetUserByGuidRequest() { }

		public GetUserByGuidRequest(Guid userGuid) : base(userGuid) { }
	}
}
