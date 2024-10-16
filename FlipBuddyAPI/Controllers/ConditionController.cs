using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.Requests.ConditionRequests.GetAllConditionsList;
using Microsoft.AspNetCore.Mvc;

namespace FlipBuddyAPI.Controllers
{

	[ApiController]
	public class ConditionController : BaseController
	{
		public ConditionController(IOrchestrator orchestrator) : base(orchestrator)
		{
		}

		[HttpGet("Category/GetAllConditions")]
		public async Task<GetAllConditionsResponse> GetAllConditions() => await _orchestrator.GetRequestResponseAsync(new GetAllConditionsRequest());
	}
}
