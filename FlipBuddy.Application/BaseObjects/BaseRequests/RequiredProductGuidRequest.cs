using FlipBuddy.Domain.Validation;
using FlipBuddy.Domain.Validation.GuidValidation;

namespace FlipBuddy.Application.BaseObjects.BaseRequests
{
    public abstract class RequiredProductGuidRequest
    {
        public RequiredProductGuidRequest() { }
        public RequiredProductGuidRequest(Guid productGuid) => ProductGuid = productGuid;


        public Guid ProductGuid { get; set; }

        public bool IsValid(out Validator validator)
        {
            validator = new(new GuidRequiredRule(ProductGuid, nameof(ProductGuid)));

            return validator.IsPassingAllRules;
        }
    }
}
