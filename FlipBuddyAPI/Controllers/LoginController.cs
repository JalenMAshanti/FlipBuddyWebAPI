using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.Requests.LoginRequests;
using Microsoft.AspNetCore.Mvc;

namespace FlipBuddyAPI.Controllers
{
	[ApiController]
	public class LoginController : BaseController
	{
		public LoginController(IOrchestrator orchestrator) : base(orchestrator)
		{
		}

		[HttpGet("Login/LoginByUsernameAndPassword")]
		public async Task<LoginByUsernameAndPasswordResponse> LoginByUsernameAndPassword([FromQuery] LoginByUsernameAndPasswordRequest request) => await _orchestrator.GetRequestResponseAsync(request);
	}
}
