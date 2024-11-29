using FlipBuddy.Application.Abstraction;
using FlipBuddy.Domain.Constants;
using FlipBuddy.Domain.Validation;
using FlipBuddy.Domain.Validation.StringValidation;

namespace FlipBuddy.Application.Requests.ProductSpecificValueRequests.Insert
{
    public class InsertProductSpecificValueRequest : IRequest, IValidatable
    {
        public InsertProductSpecificValueRequest() { }
        public InsertProductSpecificValueRequest(int specificId, string specificValue)
        {
            SpecificId = specificId;
            SpecificValue = specificValue;
        }

        public int SpecificId { get; set; }
        public string SpecificValue { get; set; } = string.Empty;

        public bool IsValid(out Validator validator)
        {
            validator = new(

                new StringLengthLimitRule(SpecificValue, nameof(SpecificValue), MaxLength.SpecificValue)
            );

            return validator.IsPassingAllRules;
        }
    }
}
