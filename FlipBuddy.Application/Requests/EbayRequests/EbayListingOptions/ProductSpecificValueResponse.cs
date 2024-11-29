namespace FlipBuddy.Application.Requests.EbayRequests.EbayListingOptions
{
    public class ProductSpecificValueResponse
    {
        public int valueId { get; set; }
        public int specificId { get; set; }
        public string specificValue { get; set; } = string.Empty;
    }
}
