using System.Xml.Serialization;

namespace FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem.Request
{
    [XmlRoot(ElementName = "PictureDetails")]
    public class PictureDetails
    {

        [XmlElement(ElementName = "PictureURL")]
        public string? PictureURL { get; set; }
    }
}
