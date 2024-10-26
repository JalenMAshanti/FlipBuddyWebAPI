using System.Xml.Serialization;

namespace FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem.Request
{
    [XmlRoot(ElementName = "ReturnPolicy")]
    public class ReturnPolicy
    {

        [XmlElement(ElementName = "ReturnsAcceptedOption")]
        public string ReturnsAcceptedOption { get; set; } = "ReturnsAccepted";

        [XmlElement(ElementName = "RefundOption")]
        public string RefundOption { get; set; } = "MoneyBack";

        [XmlElement(ElementName = "ReturnsWithinOption")]
        public string ReturnsWithinOption { get; set; } = "Days_30";

        [XmlElement(ElementName = "ShippingCostPaidByOption")]
        public string ShippingCostPaidByOption { get; set; } = "Buyer";
    }
}
