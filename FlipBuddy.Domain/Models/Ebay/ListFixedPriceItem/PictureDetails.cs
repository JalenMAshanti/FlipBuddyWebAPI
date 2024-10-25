using System.Xml.Serialization;

namespace FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem
{
	[XmlRoot(ElementName = "PictureDetails")]
	public class PictureDetails
	{

		[XmlElement(ElementName = "PictureURL")]
		public string PictureURL { get; set; }
	}
}
