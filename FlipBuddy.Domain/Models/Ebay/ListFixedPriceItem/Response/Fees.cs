using System.Xml.Serialization;

namespace FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem.Response
{
	[XmlRoot(ElementName = "Fees")]
	public class Fees
	{
		[XmlElement(ElementName = "Fee")]
		public List<Fee> Fee { get; set; } = new List<Fee>();	
	}
}
