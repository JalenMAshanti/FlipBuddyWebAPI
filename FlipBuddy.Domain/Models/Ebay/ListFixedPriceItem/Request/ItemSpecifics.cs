using System.Xml.Serialization;

namespace FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem.Request
{
    [XmlRoot(ElementName = "ItemSpecifics")]
    public class ItemSpecifics
    {

        [XmlElement(ElementName = "NameValueList")]
        public List<NameValueList>? NameValueList { get; set; }
    }
}
