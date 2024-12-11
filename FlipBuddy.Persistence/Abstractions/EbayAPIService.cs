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
							<CategoryID>{body.Item.PrimaryCategory.CategoryID}</CategoryID>
						</PrimaryCategory>
						<StartPrice>{body.Item.StartPrice}</StartPrice>
						<ConditionID>{body.Item.ConditionID}</ConditionID>
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
						
							{EbayProductSpecificsToString(body.Item.ItemSpecifics)}
						
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
				//< PictureDetails >
						//	< PictureURL ></ PictureURL >
						//</ PictureDetails >
		}

        public string EbayProductSpecificsToString(ItemSpecifics specifics)
        {
            using var stringWriter = new StringWriter();
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(ItemSpecifics));

            // Set up XmlWriter settings to omit the XML declaration
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true, // Removes the XML declaration
                Indent = true             // Optional: makes the output more readable
            };

            // Use XmlSerializerNamespaces to remove namespace attributes
            var namespaces = new System.Xml.Serialization.XmlSerializerNamespaces();
            namespaces.Add("", ""); // Add an empty namespace

            using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                serializer.Serialize(xmlWriter, specifics, namespaces);
            }

            var xmlString = stringWriter.ToString();
            return xmlString;
        }
    }
}
