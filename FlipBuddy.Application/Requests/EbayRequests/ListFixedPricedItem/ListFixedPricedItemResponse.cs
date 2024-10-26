using FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem;
using FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem.Response;

namespace FlipBuddy.Application.Requests.EbayRequests.ListFixedPricedItem
{
    public class ListFixedPricedItemResponse
    {
        public ListFixedPricedItemResponse(AddFixedPriceItemResponse response) => Response = response;

        public AddFixedPriceItemResponse Response { get; set; }
    }
}
