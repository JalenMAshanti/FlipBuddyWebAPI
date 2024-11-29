using FlipBuddy.Domain.Models;

namespace FlipBuddy.Application.Requests.EbayRequests.EbayListingOptions
{
    public class ProductSpecificResponse
    {
        public int specificId { get; set; }
        public string specificName { get; set; } = string.Empty;
        public List<ProductSpecificValueResponse>? values { get; set; }
    }
}
