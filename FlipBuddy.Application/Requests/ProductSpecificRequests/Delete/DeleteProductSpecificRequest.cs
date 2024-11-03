using FlipBuddy.Application.Abstraction;
using FlipBuddy.Domain.Validation;
using FlipBuddy.Domain.Validation.GuidValidation;

namespace FlipBuddy.Application.Requests.ProductSpecificRequests.Delete
{
    public class DeleteProductSpecificRequest : IValidatable, IRequest
    {
        public DeleteProductSpecificRequest() { }
        public DeleteProductSpecificRequest(int specificId, Guid productGuid)
        {
            SpecificId = specificId;
            ProductGuid = productGuid;
        }

        public int SpecificId { get; set; }
        public Guid ProductGuid { get; set; }

        public bool IsValid(out Validator validator)
        {
            validator = new(
                new GuidRequiredRule(ProductGuid, nameof(ProductGuid))
            );

            return validator.IsPassingAllRules;
        }
    }
}
