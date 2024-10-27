using FlipBuddy.Domain.Validation;
using FlipBuddy.Domain.Validation.GuidValidation;

namespace FlipBuddy.Application.BaseObjects.BaseRequests
{
	public abstract class RequiredGuidRequest
	{
		public RequiredGuidRequest() { }	
		public RequiredGuidRequest(Guid guid) => Guid = guid;


		public Guid Guid { get; set; }

		public bool IsValid(out Validator validator) 
		{
			validator = new(new GuidRequiredRule(Guid, nameof(Guid)));

			return validator.IsPassingAllRules;
		}
	}
}
