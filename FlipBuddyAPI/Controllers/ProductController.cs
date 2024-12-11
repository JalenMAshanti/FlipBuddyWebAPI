using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.Requests.ProductRequests.Delete;
using FlipBuddy.Application.Requests.ProductRequests.GetByGuidAndUserGuid;
using FlipBuddy.Application.Requests.ProductRequests.GetByUserGuid;
using FlipBuddy.Application.Requests.ProductRequests.Insert;
using FlipBuddy.Application.Requests.ProductRequests.Update;
using FlipBuddy.Application.Requests.ProductRequests.Upload;
using FlipBuddy.Application.Requests.ProductSpecificRequests.Delete;
using FlipBuddy.Application.Requests.ProductSpecificRequests.Get;
using FlipBuddy.Application.Requests.ProductSpecificRequests.Insert;
using FlipBuddy.Application.Requests.ProductSpecificValueRequests.Insert;
using FlipBuddy.Application.Requests.ProductSpecificValuesRequests.Delete;
using Microsoft.AspNetCore.Mvc;

namespace FlipBuddyAPI.Controllers
{
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(IOrchestrator orchestrator) : base(orchestrator) { }

        //Base Products

        [HttpPost("Product/InsertProduct")]
        public async Task InsertProduct([FromBody] InsertProductRequest request) => await _orchestrator.ExecuteRequestAsync(request);

        [HttpPost("Product/UploadBarcode")]
        public async Task UploadBarcode(InsertProductByBarcodeRequest request) => await _orchestrator.ExecuteRequestAsync(request);

        [HttpGet("Product/GetProductsByUserGuid")]
        public async Task<GetProductsByUserGuidResponse> GetProductsByUserGuid([FromQuery] GetProductsByUserGuidRequest request) => await _orchestrator.GetRequestResponseAsync(request);

        [HttpGet("Product/GetProductByGuidAndUserGuid")]
        public async Task<GetProductByGuidAndUserGuidResponse> GetProductByGuidandUserGuid([FromQuery] GetProductByGuidAndUserGuidRequest request) => await _orchestrator.GetRequestResponseAsync(request);

        [HttpPut("Product/UpdateProductByGuidAndUserGuid")]
        public async Task UpdateProductByGuidAndUserGuid([FromBody] UpdateProductByGuidAndUserGuidRequest request) => await _orchestrator.ExecuteRequestAsync(request);

        [HttpDelete("Product/DeleteProductByProductGuid")]
        public async Task DeleteProductByProductGuid([FromQuery] DeleteProductByProductGuidRequest request) => await _orchestrator.ExecuteRequestAsync(request);



        //Product Specifics
        
        [HttpDelete("Product/DeleteProductSpecific")]
        public async Task DeleteProductSpecific([FromQuery] DeleteProductSpecificRequest request) => await _orchestrator.ExecuteRequestAsync(request);

        [HttpGet("Product/GetProductSpecifics")]
        public async Task<GetProductSpecificsResponse> GetProductSpecifics([FromQuery] GetProductSpecificsRequest request) => await _orchestrator.GetRequestResponseAsync(request);

        [HttpPost("Product/InsertProductSpecific")]
        public async Task InsertProductSpecific([FromBody] InsertProductSpecificRequest request) => await _orchestrator.ExecuteRequestAsync(request);


        //Proudct Specific Values
        [HttpDelete("Product/DeleteProductSpecificValue")]
        public async Task DeleteProductSpecificValue([FromBody] DeleteProductSpecificValueRequest request) => await _orchestrator.ExecuteRequestAsync(request);

        [HttpPost("Product/InsertProductSpecificValue")]
        public async Task InsertProductSpecificValue([FromBody] InsertProductSpecificValueRequest request) => await _orchestrator.ExecuteRequestAsync(request);

    }
}
