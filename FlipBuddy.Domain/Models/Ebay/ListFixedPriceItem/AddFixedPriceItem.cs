using System.Xml.Serialization;

namespace FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem
{

	[XmlRoot(ElementName = "AddFixedPriceItemRequest")]
	public class AddFixedPriceItemRequest
	{

		[XmlElement(ElementName = "ErrorLanguage")]
		public string ErrorLanguage { get; set; } = "en_US";

		[XmlElement(ElementName = "WarningLevel")]
		public int WarningLevel { get; set; } = 1;

		[XmlElement(ElementName = "Item")]
		public Item Item { get; set; }

		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; } = "urn:ebay:apis:eBLBaseComponents";

		[XmlText]
		public string Text { get; set; }
	}
}
