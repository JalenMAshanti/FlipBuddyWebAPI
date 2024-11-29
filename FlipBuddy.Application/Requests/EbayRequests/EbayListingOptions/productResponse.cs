namespace FlipBuddy.Application.Requests.EbayRequests.EbayListingOptions
{
    public class productResponse
    {
        public string productGuid { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public int categoryId { get; set; }
        public int ebayCategoryId { get; set; }
        public decimal purchasePrice { get; set; }
        public decimal sellPrice { get; set; }
        public string description { get; set; } = string.Empty;
        public int quantity { get; set; }
        public string currency { get; set; } = string.Empty;
        public int conditionId { get; set; }
        public string barcode { get; set; }
        public string dateSold { get; set; }
    }
}
