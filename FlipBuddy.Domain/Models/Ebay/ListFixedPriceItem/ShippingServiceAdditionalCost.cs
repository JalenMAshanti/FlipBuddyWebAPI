using System.Xml.Serialization;

namespace FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem
{
	[XmlRoot(ElementName = "ShippingServiceAdditionalCost")]
	public class ShippingServiceAdditionalCost
	{

		[XmlAttribute(AttributeName = "currencyID")]
		public string CurrencyID { get; set; }

		[XmlText]
		public double Text { get; set; }
	}
}
