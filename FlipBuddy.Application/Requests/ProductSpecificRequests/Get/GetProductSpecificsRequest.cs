using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.BaseObjects.BaseRequests;

namespace FlipBuddy.Application.Requests.ProductSpecificRequests.Get
{
	public class GetProductSpecificsRequest : RequiredProductGuidRequest, IRequestResponse<GetProductSpecificsResponse>
	{
		public GetProductSpecificsRequest() { }

		public GetProductSpecificsRequest(Guid guid) : base(guid) { }
	}
}
