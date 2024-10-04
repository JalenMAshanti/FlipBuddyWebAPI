using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.BaseObjects.BaseRequests;

namespace FlipBuddy.Application.Requests.ProductRequests.Get
{
	public class GetProductsByUserGuidRequest : RequiredUserGuidRequest, IRequestResponse<GetProductsByUserGuidResponse>
	{
		public GetProductsByUserGuidRequest() { }
		public GetProductsByUserGuidRequest(Guid userGuid) : base(userGuid) { }
	}
}
