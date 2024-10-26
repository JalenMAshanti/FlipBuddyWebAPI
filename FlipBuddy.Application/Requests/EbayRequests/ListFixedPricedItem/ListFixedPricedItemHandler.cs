using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Application.Requests.EbayRequests.ListFixedPricedItem
{
	internal class ListFixedPricedItemHandler : DataRequestResponseHandler<ListFixedPricedItemRequest, ListFixedPricedItemResponse>
	{
		public ListFixedPricedItemHandler(IDataAccess dataAccess, EbayAPIService ebayService) : base(dataAccess, ebayService)
		{
		}

		public override async Task<ListFixedPricedItemResponse> GetResponseAsync(ListFixedPricedItemRequest request)
		{
			try
			{
				if (request.ListItemDetails is null)
				{
					throw new OperationFailedException();
				}
				else
				{
					var result = await _ebayAPISerice.AddFixedPricedItemAPIRequest("https://api.sandbox.ebay.com/ws/api.dll", request.ListItemDetails, request.Token);

					return new ListFixedPricedItemResponse(result);
				}

			}
			catch (Exception ex)
			{
				throw new NotImplementedException();
			}
		}
	}
}
