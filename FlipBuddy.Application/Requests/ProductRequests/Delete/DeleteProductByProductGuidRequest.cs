using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.BaseObjects.BaseRequests;

namespace FlipBuddy.Application.Requests.ProductRequests.Delete
{
    public class DeleteProductByProductGuidRequest : RequiredProductGuidRequest, IRequest
    {
        public DeleteProductByProductGuidRequest() { }

        public DeleteProductByProductGuidRequest(Guid productGuid) : base(productGuid) { }
    }
}
