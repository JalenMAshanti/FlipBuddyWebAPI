using System.Xml.Serialization;

namespace FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem.Request
{
    [XmlRoot(ElementName = "ShippingServiceOptions")]
    public class ShippingServiceOptions
    {

        [XmlElement(ElementName = "ShippingServicePriority")]
        public int ShippingServicePriority { get; set; }

        [XmlElement(ElementName = "ShippingService")]
        public string ShippingService { get; set; } = string.Empty;

        [XmlElement(ElementName = "FreeShipping")]
        public bool FreeShipping { get; set; }

        [XmlElement(ElementName = "ShippingServiceAdditionalCost")]
        public ShippingServiceAdditionalCost? ShippingServiceAdditionalCost { get; set; }
    }
}
