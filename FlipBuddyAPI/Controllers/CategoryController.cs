using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.Requests.CategoryRequests.GetAllCategoriesList;
using Microsoft.AspNetCore.Mvc;

namespace FlipBuddyAPI.Controllers
{
	[ApiController]
	public class CategoryController : BaseController
	{
		public CategoryController(IOrchestrator orchestrator) : base(orchestrator)
		{
		}

		[HttpGet("Category/GetAllCategories")]
		public async Task<GetAllCategoriesResponse> GetAllCategories() => await _orchestrator.GetRequestResponseAsync(new GetAllCategoriesRequest());
	}
}
