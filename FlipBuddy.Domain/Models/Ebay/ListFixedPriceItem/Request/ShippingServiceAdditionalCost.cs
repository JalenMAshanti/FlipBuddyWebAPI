using System.Xml.Serialization;

namespace FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem.Request
{
    [XmlRoot(ElementName = "ShippingServiceAdditionalCost")]
    public class ShippingServiceAdditionalCost
    {

        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID { get; set; } = string.Empty;

        [XmlText]
        public double Text { get; set; }
    }
}
