using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Application.Helpers;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.Implementation;

namespace FlipBuddy.Application.Requests.EbayRequests.ListFixedPricedItem
{
	internal class ListFixedPricedItemHandler : DataRequestResponseHandler<ListFixedPricedItemRequest, ListFixedPricedItemResponse>
	{
		public ListFixedPricedItemHandler(IDataAccess dataAccess, ExternalEbayAPIService ebayApiService) : base(dataAccess, ebayApiService)
		{
		}

		public override async Task<ListFixedPricedItemResponse> GetResponseAsync(ListFixedPricedItemRequest request)
		{
			try
			{

				var ebayConverters = new EbayConverters();

				var listing = await ebayConverters.GenerateEbayFixedPricedItemRequest(request);

				var result = await _ebayAPISerice.ListFixedPricedItemV2(listing, request.token);

				return new ListFixedPricedItemResponse(result);
			}
			catch (Exception ex)
			{
				throw new NotImplementedException();
			}
		}
	}
}
