using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.Requests.ProductRequests.Get;
using FlipBuddy.Application.Requests.ProductRequests.Insert;
using FlipBuddy.Application.Requests.ProductRequests.Upload;
using Microsoft.AspNetCore.Mvc;

namespace FlipBuddyAPI.Controllers
{
	[ApiController]
	public class ProductController : BaseController
	{
		public ProductController(IOrchestrator orchestrator) : base(orchestrator) { }

		[HttpPost("Product/InsertProduct")]
		public async Task InsertProduct([FromBody] InsertProductRequest request) => await _orchestrator.ExecuteRequestAsync(request);

		[HttpPost("Product/UploadBarcode")]
		public async Task UploadBarcode(InsertProductByBarcodeRequest request) => await _orchestrator.ExecuteRequestAsync(request);

		[HttpGet("Product/GetProductsByUserGuid")]
		public async Task<GetProductsByUserGuidResponse> GetProductsByUserGuid([FromQuery]GetProductsByUserGuidRequest request) => await _orchestrator.GetRequestResponseAsync(request);
	}
}
