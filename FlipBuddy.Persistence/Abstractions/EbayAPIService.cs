using FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem.Request;
using FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem.Response;
using FlipBuddy.Persistence.Implementation;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace FlipBuddy.Persistence.Abstractions
{
    public abstract class EbayAPIService 
	{
		private readonly ClientFactory _clientFactory;
		public EbayAPIService(ClientFactory clientFactory) => _clientFactory = clientFactory;

		public async Task<AddFixedPriceItemResponse> ListFixedPricedItemV2(AddFixedPriceItemRequest body, string token)
		{
			using (var client = new HttpClient())
			{
				// Set up eBay API endpoint URL
				var apiEndpoint = "https://api.sandbox.ebay.com/ws/api.dll";

				// Set up headers
				
				client.DefaultRequestHeaders.Add("X-EBAY-API-SITEID", "0"); // Adjust the site ID as needed
				client.DefaultRequestHeaders.Add("X-EBAY-API-COMPATIBILITY-LEVEL", "967"); // Compatibility level for the API
				client.DefaultRequestHeaders.Add("X-EBAY-API-CALL-NAME", "AddFixedPriceItem");
				client.DefaultRequestHeaders.Add("X-EBAY-API-IAF-TOKEN", token);

				// XML payload
				var xmlPayload = $@"<?xml version=""1.0"" encoding=""utf-8""?>
				<AddFixedPriceItemRequest xmlns=""urn:ebay:apis:eBLBaseComponents"">
					<ErrorLanguage>en_US</ErrorLanguage>
					<WarningLevel>High</WarningLevel>
					<Item>
						<Title>{body.Item.Title}</Title>
						<Description>{body.Item.Description}</Description>
						<PrimaryCategory>
							<CategoryID>9355</CategoryID>
						</PrimaryCategory>
						<StartPrice>{body.Item.StartPrice}</StartPrice>
						<ConditionID>1000</ConditionID>
						<Country>{body.Item.Country}</Country>
						<Currency>{body.Item.Currency}</Currency>
						<DispatchTimeMax>1</DispatchTimeMax>
						<ListingDuration>GTC</ListingDuration>
						<ListingType>FixedPriceItem</ListingType>
						
						<PostalCode>95125</PostalCode>
						<ProductListingDetails>
							<UPC></UPC>
							<IncludeStockPhotoURL>true</IncludeStockPhotoURL>
							<IncludeeBayProductDetails>true</IncludeeBayProductDetails>
							<UseFirstProduct>true</UseFirstProduct>
							<ReturnSearchResultOnDuplicates>true</ReturnSearchResultOnDuplicates>
						</ProductListingDetails>

						<Quantity>{body.Item.Quantity}</Quantity>
						<ReturnPolicy>
							<ReturnsAcceptedOption>{body.Item.ReturnPolicy.ReturnsAcceptedOption}</ReturnsAcceptedOption>
							<RefundOption>{body.Item.ReturnPolicy.RefundOption}</RefundOption>
							<ReturnsWithinOption>{body.Item.ReturnPolicy.ReturnsWithinOption}</ReturnsWithinOption>
							<ShippingCostPaidByOption>{body.Item.ReturnPolicy.ShippingCostPaidByOption}</ShippingCostPaidByOption>
						</ReturnPolicy>
						<ShippingDetails>
							<ShippingType>Flat</ShippingType>
							<ShippingServiceOptions>
								<ShippingServicePriority>1</ShippingServicePriority>
								<ShippingService>{body.Item.ShippingDetails.ShippingServiceOptions.ShippingService}</ShippingService>
								<FreeShipping>{body.Item.ShippingDetails.ShippingServiceOptions.FreeShipping}</FreeShipping>
							</ShippingServiceOptions>
						</ShippingDetails>
						<Site>US</Site>
					</Item>
				</AddFixedPriceItemRequest>";

				var content = new StringContent(xmlPayload, Encoding.UTF8, "text/xml");

				try
				{
					// Send the request
					var response = await client.PostAsync(apiEndpoint, content);
					var responseString = await response.Content.ReadAsStringAsync();

					// Deserialize XML response
					XmlSerializer serializer = new XmlSerializer(typeof(AddFixedPriceItemResponse));
					using (StringReader reader = new StringReader(responseString))
					{
						var result = (AddFixedPriceItemResponse)serializer.Deserialize(reader);
						return result;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error: {ex.Message}");
					throw;
				}
			}
		}

		public void EbayProductImagesUrlToString() 
		{

		}

		public void EbayProductSpecificsToString() 
		{
						//< PictureDetails >
						//	< PictureURL ></ PictureURL >
						//</ PictureDetails >
		}
	}
}
