namespace FlipBuddy.Application.Requests.EbayRequests.EbayListingOptions
{
    public class productAndSpecificsResponse
    {
        public productResponse product { get; set; }
        public List<ProductSpecificResponse>? productSpecifics { get; set; }
    }
}
