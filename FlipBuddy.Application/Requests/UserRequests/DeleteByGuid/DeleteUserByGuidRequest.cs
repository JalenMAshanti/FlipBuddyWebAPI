using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.BaseObjects.BaseRequests;

namespace FlipBuddy.Application.Requests.UserRequests.DeleteByGuid
{
	public class DeleteUserByGuidRequest : RequiredUserGuidRequest, IRequest
	{
		public DeleteUserByGuidRequest() { }

		public DeleteUserByGuidRequest(Guid guid) : base(guid) { } 	
	}
}
