using FlipBuddy.Application.Abstraction;
using FlipBuddy.Domain.Validation;
using FlipBuddy.Domain.Validation.GuidValidation;

namespace FlipBuddy.Application.Requests.ProductRequests.GetByGuidAndUserGuid
{
	public class GetProductByGuidAndUserGuidRequest : IValidatable, IRequestResponse<GetProductByGuidAndUserGuidResponse>
	{
		public GetProductByGuidAndUserGuidRequest() { }

		public GetProductByGuidAndUserGuidRequest(Guid guid, Guid userGuid)
		{
			Guid = guid;
			UserGuid = userGuid;
		}

		public Guid Guid { get; set; }
		public Guid UserGuid { get; set; }

		public bool IsValid(out Validator validator)
		{
			validator = new(
				new GuidRequiredRule(Guid, nameof(Guid)),
				new GuidRequiredRule(UserGuid, nameof(UserGuid))
			);

			return validator.IsPassingAllRules;
		}
	}
}
