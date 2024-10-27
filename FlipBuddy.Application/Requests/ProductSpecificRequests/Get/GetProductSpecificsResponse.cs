using FlipBuddy.Domain.Models;

namespace FlipBuddy.Application.Requests.ProductSpecificRequests.Get
{
	public class GetProductSpecificsResponse
	{
		public GetProductSpecificsResponse(IEnumerable<ProductSpecific> specifics) => Specifics = specifics;

		IEnumerable<ProductSpecific> Specifics { get; set; }
	}
}
