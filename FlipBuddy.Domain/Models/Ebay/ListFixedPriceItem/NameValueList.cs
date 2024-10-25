using System.Xml.Serialization;

namespace FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem
{
	[XmlRoot(ElementName = "NameValueList")]
	public class NameValueList
	{

		[XmlElement(ElementName = "Value")]
		public List<string> Value { get; set; }

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }
	}
}
