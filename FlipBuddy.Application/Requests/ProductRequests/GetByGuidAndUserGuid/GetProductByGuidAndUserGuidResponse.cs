using FlippBuddy.Domain.Models;

namespace FlipBuddy.Application.Requests.ProductRequests.GetByGuidAndUserGuid
{
	public class GetProductByGuidAndUserGuidResponse
	{
		public GetProductByGuidAndUserGuidResponse(Product product)  => Product = product;

		public Product Product { get; set; }
	}
}
