using FlipBuddy.Application.Abstraction;
using FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Serialization;

namespace FlipBuddyAPI.Controllers
{

	[ApiController]
	public class EbayController : BaseController
	{
		public EbayController(IOrchestrator orchestrator) : base(orchestrator)
		{
		}

		[HttpGet("EbayController/ListItemFromInventory")]
		public async Task ListItemToEbay()
		{
			string token = "";

			var Listing = new AddFixedPriceItemRequest()
			{
				Item = new Item
				{
					Title = @"Apple MacBook Pro MB990LL / A 13.3 in. Notebook NEW",
					Description = "Brand New Apple MacBook Pro MB990LL/A 13.3 in. Notebook!",

					PrimaryCategory = new PrimaryCategory
					{
						CategoryID = 111422,
					},

					StartPrice = 500.0,
					ConditionID = 1000,
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
						UPC = 885909298594,
						IncludeStockPhotoURL = true,
						UseFirstProduct = true,
						ReturnSearchResultOnDuplicates = true,
					},

					ItemSpecifics = new ItemSpecifics
					{
						NameValueList = new List<NameValueList>
						{
							new NameValueList
							{
								Name = "Brand",
								Value = new List<string> { "Apple" }
							},

							new NameValueList
							{
								Name = "Screen Size",
								Value = new List<string> { "13.3 in" }
							},

							new NameValueList
							{
								Name = "Features",
								Value = new List<string> { "Apple Mac OS X 10.7 Mountain Lion", "LED-backlit Glass Display", "Glass Trackpad", "FireWire 800 port", "Bluetooth 2.1+EDR", "Mini DisplayPort video output", "Secure Digital card slot" }
							}

						},

					},

					Quantity = 1,

					ReturnPolicy = new ReturnPolicy
					{
						ReturnsAcceptedOption = "ReturnsAccepted",
						RefundOption = "MoneyBack",
						ReturnsWithinOption = "Days_30",
						ShippingCostPaidByOption = "Buyer",
					},

					ShippingDetails = new ShippingDetails 
					{
						ShippingType = "Flat",

						ShippingServiceOptions = new ShippingServiceOptions 
						{
							ShippingServicePriority = 1,
							ShippingService = "UPSGround",
							FreeShipping = true,
							ShippingServiceAdditionalCost = new ShippingServiceAdditionalCost 
							{
								CurrencyID = "USD",
								Text = 0.00,
							}
						},
					},
					
					Site = "US",
				}
			};






			XmlSerializer serializer = new XmlSerializer(typeof(AddFixedPriceItemRequest));

			string xmlContent;
			using (StringWriter stringWriter = new StringWriter())
			{
				serializer.Serialize(stringWriter, Listing);
				xmlContent = stringWriter.ToString();
			}

			HttpClient client = new HttpClient();

			client.DefaultRequestHeaders.Add("X-EBAY-API-SITEID", "0");
			client.DefaultRequestHeaders.Add("X-EBAY-API-COMPATIBILITY-LEVEL", "967");
			client.DefaultRequestHeaders.Add("X-EBAY-API-CALL-NAME", "AddFixedPriceItem");
			client.DefaultRequestHeaders.Add("X-EBAY-API-IAF-TOKEN", token);

			HttpContent content = new StringContent(xmlContent, Encoding.UTF8, "application/xml");

			HttpResponseMessage response = await client.PostAsync("https://api.example.com/endpoint", content);

		}
	}
}
