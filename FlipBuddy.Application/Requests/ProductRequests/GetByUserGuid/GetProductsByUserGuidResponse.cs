using FlipBuddy.Persistence.DTO;
using FlippBuddy.Domain.Models;

namespace FlipBuddy.Application.Requests.ProductRequests.Get
{
	public class GetProductsByUserGuidResponse
	{
		public GetProductsByUserGuidResponse(IEnumerable<Products_DTO> products) => Products = products;

		IEnumerable<Products_DTO> Products { get; set; }
	}
}
