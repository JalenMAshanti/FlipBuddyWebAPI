using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.Requests.UserRequests.DeleteByGuid;
using FlipBuddy.Application.Requests.UserRequests.GetByGuid;
using FlipBuddy.Application.Requests.UserRequests.Insert;
using Microsoft.AspNetCore.Mvc;

namespace FlipBuddyAPI.Controllers
{

	[ApiController]
	public class UserController : BaseController
	{
		public UserController(IOrchestrator orchestrator) : base(orchestrator)
		{
		}

		[HttpPost("User/InsertUser")]
		public async Task InsertUser([FromBody] InsertUserRequest request) => await _orchestrator.ExecuteRequestAsync(request);

		[HttpGet("User/GetUserByGuid")]
		public async Task<GetUserByGuidResponse> GetUserByGuid([FromQuery]GetUserByGuidRequest request) => await _orchestrator.GetRequestResponseAsync(request);

		[HttpDelete("User/DeleteUserByGuid")]
		public async Task DeleteUserByGuid([FromBody]DeleteUserByGuidRequest request) => await _orchestrator.ExecuteRequestAsync(request);
	}
}
