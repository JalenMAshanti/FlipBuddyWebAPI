using FlipBuddy.Application.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;

namespace FlipBuddyAPI.Controllers
{
	
	[ApiController]
	public class GuidController : BaseController
	{
		public GuidController(IOrchestrator orchestrator) : base(orchestrator)
		{
		}

		[HttpGet("Guid/GetNewGuid")]
		public async Task<Guid> GetNewGuid()
		{
			var result = Guid.NewGuid();
			return await Task.FromResult(result);
		}
	}
}
