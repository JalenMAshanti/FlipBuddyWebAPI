using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.Requests.EbayRequests.EbayListingOptions;

namespace FlipBuddy.Application.Requests.EbayRequests.ListFixedPricedItem
{
    public class ListFixedPricedItemRequest : IRequestResponse<ListFixedPricedItemResponse>
    {
        public ListFixedPricedItemRequest() { }

        public ListFixedPricedItemRequest(productAndSpecificsResponse ProductAndSpecifics,
                                          string ReturnsAccepted,
                                          string ReturnsWithin,
                                          string ReturnShippingCostPaidBy,
                                          bool FreeShipping,
                                          int ShippingServicePriority,
                                          string ShippingService,
                                          double AdditionalShippingCosts,
                                          string Token)
        {

            ProductAndSpecifics = productandSpecifics;
            ReturnsAccepted = returnsAccepted;
            ReturnsWithin = returnsWithin;
            ReturnShippingCostPaidBy = returnShippingCostPaidBy;
            FreeShipping = freeShipping;
            ShippingServicePriority = shippingServicePriority;
            ShippingService = shippingService;
            AdditionalShippingCosts = additionalShippingCosts;
            Token = token;
        }

        //Product
        public productAndSpecificsResponse productandSpecifics { get; set; }

        //Return Settings
        public string returnsAccepted { get; set; } = "ReturnsAccepted";
        public string returnsWithin { get; set; } = "Days_30";
        public string returnShippingCostPaidBy { get; set; } = "Buyer";


        //Shipping Settings  
        public bool freeShipping { get; set; } = true;
        public int shippingServicePriority { get; set; } = 1;
        public string shippingService { get; set; } = "UPSGround";
        public double additionalShippingCosts { get; set; }
        public string token { get; set; } = string.Empty;
    }
}
