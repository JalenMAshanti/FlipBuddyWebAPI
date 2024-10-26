using System.Xml.Serialization;

namespace FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem.Request
{

    [XmlRoot(ElementName = "PrimaryCategory")]
    public class PrimaryCategory
    {

        [XmlElement(ElementName = "CategoryID")]
        public int CategoryID { get; set; }
    }
}
