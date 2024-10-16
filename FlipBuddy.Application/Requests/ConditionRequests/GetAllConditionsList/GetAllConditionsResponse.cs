using FlipBuddy.Domain.Models;

namespace FlipBuddy.Application.Requests.ConditionRequests.GetAllConditionsList
{
	public class GetAllConditionsResponse
	{
		public GetAllConditionsResponse(IEnumerable<Condition> conditions) => Conditions = conditions;

		public IEnumerable<Condition> Conditions { get; set; }
	}
}
