using FlipBuddy.Application.Abstraction;
using FlipBuddy.Domain.Constants;
using FlipBuddy.Domain.Validation;
using FlipBuddy.Domain.Validation.GuidValidation;
using FlipBuddy.Domain.Validation.StringValidation;

namespace FlipBuddy.Application.Requests.ProductSpecificRequests.Insert
{
	public class InsertProductSpecificRequest : IValidatable, IRequest
	{
		public InsertProductSpecificRequest() { }
		public InsertProductSpecificRequest(Guid productGuid, string specificName)
		{
			ProductGuid = productGuid;
			SpecificName = specificName;
		}

		public Guid ProductGuid { get; set; }
		public string? SpecificName { get; set; } 


		public bool IsValid(out Validator validator)
		{
			validator = new (
				new GuidRequiredRule(ProductGuid, nameof(ProductGuid)),
				new StringLengthLimitRule(SpecificName, nameof(SpecificName), MaxLength.SpecificName)
			);

			return validator.IsPassingAllRules;
		}
	}
}
