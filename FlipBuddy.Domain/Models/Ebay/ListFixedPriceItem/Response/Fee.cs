using System.Xml.Serialization;

namespace FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem.Response
{
	[XmlRoot(ElementName = "Fee")]
	public class Fee
	{
		[XmlAttribute(AttributeName = "currencyID")]
		public string CurrencyID { get; set; } = string.Empty;

		[XmlText]
		public double Text { get; set; }

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; } = string.Empty;
	}
}
