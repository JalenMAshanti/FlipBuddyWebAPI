using FlipBuddy.Application.Requests.EbayRequests.ListFixedPricedItem;
using FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem.Request;

namespace FlipBuddy.Application.Helpers
{
	public class EbayConverters
	{

		public async Task<AddFixedPriceItemRequest> GenerateEbayFixedPricedItemRequest(ListFixedPricedItemRequest request)
		{
			var itemSpecifics = new ItemSpecifics();
			
			if (request.productandSpecifics.productSpecifics != null) 
			{
				itemSpecifics.NameValueList = new List<NameValueList>();

				foreach (var specific in request.productandSpecifics.productSpecifics) 
				{
					var nameValueList = new NameValueList();

					nameValueList.Name = specific.specificName;

					if (specific.values != null) 
					{
						foreach (var specificValue in specific.values) 
						{
							nameValueList.Value = new List<string>();
							nameValueList.Value.Add(specificValue.specificValue);							
						}					
					}
					

					itemSpecifics.NameValueList.Add(nameValueList);
				}
			}

			double upcValue = 0;

			// Try parsing the barcode as an integer, and convert it to double if successful
			if (int.TryParse(request.productandSpecifics.product.barcode, out int parsedInt))
			{
				upcValue = parsedInt;
			}


			var Listing = new AddFixedPriceItemRequest()
			{
				ErrorLanguage = "en_US",
				WarningLevel = 0,

				Item = new Item
				{
					Title = request.productandSpecifics.product.title,
					Description = request.productandSpecifics.product.description,

					PrimaryCategory = new PrimaryCategory
					{
						CategoryID = request.productandSpecifics.product.ebayCategoryId,
					},

					StartPrice = (double)request.productandSpecifics.product.sellPrice,
					ConditionID = request.productandSpecifics.product.conditionId,
					Country = "US",
					Currency = "USD",
					DispatchTimeMax = 1,
					ListingType = "FixedPriceItem",

					PictureDetails = new PictureDetails
					{
						PictureURL = "",
					},
					PostalCode = 95125,

					ProductListingDetails = new ProductListingDetails
					{
						UPC = upcValue,
						IncludeStockPhotoURL = true,
						UseFirstProduct = true,
						ReturnSearchResultOnDuplicates = true,
					},

					ItemSpecifics = itemSpecifics,

					Quantity = request.productandSpecifics.product.quantity,

					ReturnPolicy = new ReturnPolicy
					{
						ReturnsAcceptedOption = request.returnsAccepted,
						RefundOption = "MoneyBack",
						ReturnsWithinOption = request.returnsWithin,
						ShippingCostPaidByOption = request.returnShippingCostPaidBy,
					},

					ShippingDetails = new ShippingDetails
					{
						ShippingType = "Flat",

						ShippingServiceOptions = new ShippingServiceOptions
						{
							ShippingServicePriority = 1,
							ShippingService = request.shippingService,
							FreeShipping = request.freeShipping,
							ShippingServiceAdditionalCost = new ShippingServiceAdditionalCost
							{
								CurrencyID = "USD",
								Text = request.additionalShippingCosts,
							}
						},
					},

					Site = "US",
				}
			};

			return Listing;
		}
	}
}
