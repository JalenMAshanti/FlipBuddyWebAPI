﻿using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.Requests.ProductRequests.GetByGuidAndUserGuid;
using FlipBuddy.Application.Requests.ProductRequests.GetByUserGuid;
using FlipBuddy.Application.Requests.ProductRequests.Insert;
using FlipBuddy.Application.Requests.ProductRequests.Update;
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
        public async Task<GetProductsByUserGuidResponse> GetProductsByUserGuid([FromQuery] GetProductsByUserGuidRequest request) => await _orchestrator.GetRequestResponseAsync(request);

        [HttpGet("Product/GetProductByGuidAndUserGuid")]
        public async Task<GetProductByGuidAndUserGuidResponse> GetProductByGuidandUserGuid([FromQuery] GetProductByGuidAndUserGuidRequest request) => await _orchestrator.GetRequestResponseAsync(request);

        [HttpPut("Product/UpdateProductByGuidAndUserGuid")]
        public async Task UpdateProductByGuidAndUserGuid([FromBody] UpdateProductByGuidAndUserGuidRequest request) => await _orchestrator.ExecuteRequestAsync(request);
    }
}
