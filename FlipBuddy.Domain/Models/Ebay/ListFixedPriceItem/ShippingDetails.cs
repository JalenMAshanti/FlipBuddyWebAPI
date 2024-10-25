using System.Xml.Serialization;

namespace FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem
{
	[XmlRoot(ElementName = "ShippingDetails")]
	public class ShippingDetails
	{

		[XmlElement(ElementName = "ShippingType")]
		public string ShippingType { get; set; } = "Flat";

		[XmlElement(ElementName = "ShippingServiceOptions")]
		public ShippingServiceOptions ShippingServiceOptions { get; set; }
	}
}
