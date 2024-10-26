using FlipBuddy.Application.Abstraction;
using FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem.Request;

namespace FlipBuddy.Application.Requests.EbayRequests.ListFixedPricedItem
{
    public class ListFixedPricedItemRequest : IRequestResponse<ListFixedPricedItemResponse>
    {
        public ListFixedPricedItemRequest() { }

        public ListFixedPricedItemRequest(AddFixedPriceItemRequest listItemRequest, string token)
        {
            ListItemDetails = listItemRequest;
            Token = token;
        }

        public AddFixedPriceItemRequest? ListItemDetails { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
