using FlipBuddy.Domain.Validation;
using FlipBuddy.Domain.Validation.GuidValidation;

namespace FlipBuddy.Application.BaseObjects.BaseRequests
{
	public abstract class RequiredUserGuidRequest
	{
		public RequiredUserGuidRequest() { }	
		public RequiredUserGuidRequest(Guid userGuid) => UserGuid = userGuid;


		public Guid UserGuid { get; set; }

		public bool IsValid(out Validator validator) 
		{
			validator = new(new GuidRequiredRule(UserGuid, nameof(UserGuid)));

			return validator.IsPassingAllRules;
		}
	}
}
