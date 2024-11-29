using FlipBuddy.Application.Abstraction;

namespace FlipBuddy.Application.Requests.ProductSpecificValuesRequests.Delete
{
    public class DeleteProductSpecificValueRequest : IRequest
    {
        public DeleteProductSpecificValueRequest() { }

        public DeleteProductSpecificValueRequest(int valueId, int specificId)
        {
            ValueId = valueId;
            SpecificId = specificId;
        }

        public int ValueId { get; set; }
        public int SpecificId { get; set; }
    }
}
