using FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem.Request;
using FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem.Response;
using FlipBuddy.Persistence.Implementation;
using System.Text;
using System.Xml.Serialization;

namespace FlipBuddy.Persistence.Abstractions
{
    public abstract class EbayAPIService 
	{
		private readonly ClientFactory _clientFactory;
		public EbayAPIService(ClientFactory clientFactory) => _clientFactory = clientFactory;

		public async Task<AddFixedPriceItemResponse> AddFixedPricedItemAPIRequest(string url, Object body, string token)
		{
			string xmlContent = string.Empty;

			XmlSerializer serializer = new XmlSerializer(typeof(AddFixedPriceItemRequest));

			using (StringWriter stringWriter = new StringWriter())
			{
				serializer.Serialize(stringWriter, body);
				xmlContent = stringWriter.ToString();
			}

			var client = _clientFactory.CreateNewClient();

			client.DefaultRequestHeaders.Add("X-EBAY-API-SITEID", "0");
			client.DefaultRequestHeaders.Add("X-EBAY-API-COMPATIBILITY-LEVEL", "967");
			client.DefaultRequestHeaders.Add("X-EBAY-API-CALL-NAME", "AddFixedPriceItem");
			client.DefaultRequestHeaders.Add("X-EBAY-API-IAF-TOKEN", token);

			HttpContent content = new StringContent(xmlContent, Encoding.UTF8, "application/xml");

			HttpResponseMessage response = await client.PostAsync(url, content);

			response.EnsureSuccessStatusCode();

			using Stream responseStream = await response.Content.ReadAsStreamAsync();

			// Deserialize the XML response to MyResponseModel
			serializer = new XmlSerializer(typeof(AddFixedPriceItemResponse));

			var result = (AddFixedPriceItemResponse)serializer.Deserialize(responseStream);
			
			return result;
		}
	}
}
