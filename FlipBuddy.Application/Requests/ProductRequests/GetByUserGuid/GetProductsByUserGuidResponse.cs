using FlipBuddy.Persistence.DTO;
using FlippBuddy.Domain.Models;

namespace FlipBuddy.Application.Requests.ProductRequests.GetByUserGuid
{
	public class GetProductsByUserGuidResponse
	{
		public GetProductsByUserGuidResponse(IEnumerable<Product> products) => Products = products;

		public IEnumerable<Product> Products { get; set; }
	}
}
