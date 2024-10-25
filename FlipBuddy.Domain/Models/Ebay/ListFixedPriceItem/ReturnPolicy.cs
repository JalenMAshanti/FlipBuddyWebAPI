using System.Xml.Serialization;

namespace FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem
{
	[XmlRoot(ElementName = "ReturnPolicy")]
	public class ReturnPolicy
	{

		[XmlElement(ElementName = "ReturnsAcceptedOption")]
		public string ReturnsAcceptedOption { get; set; }

		[XmlElement(ElementName = "RefundOption")]
		public string RefundOption { get; set; }

		[XmlElement(ElementName = "ReturnsWithinOption")]
		public string ReturnsWithinOption { get; set; }

		[XmlElement(ElementName = "ShippingCostPaidByOption")]
		public string ShippingCostPaidByOption { get; set; }
	}
}
