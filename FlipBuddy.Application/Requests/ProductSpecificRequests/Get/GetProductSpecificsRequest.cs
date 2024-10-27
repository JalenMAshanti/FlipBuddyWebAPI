using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.BaseObjects.BaseRequests;

namespace FlipBuddy.Application.Requests.ProductSpecificRequests.Get
{
	public class GetProductSpecificsRequest : RequiredUserGuidRequest, IRequestResponse<GetProductSpecificsResponse>
	{
		public GetProductSpecificsRequest() { }

		public GetProductSpecificsRequest(Guid guid) : base(guid) { }
	}
}
