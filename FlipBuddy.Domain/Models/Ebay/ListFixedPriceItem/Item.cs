using System.Xml.Serialization;

namespace FlipBuddy.Domain.Models.Ebay.ListFixedPriceItem
{
	[XmlRoot(ElementName = "Item")]
	public class Item
	{

		[XmlElement(ElementName = "Title")]
		public string Title { get; set; }

		[XmlElement(ElementName = "Description")]
		public string Description { get; set; }

		[XmlElement(ElementName = "PrimaryCategory")]
		public PrimaryCategory PrimaryCategory { get; set; }

		[XmlElement(ElementName = "StartPrice")]
		public double StartPrice { get; set; }

		[XmlElement(ElementName = "ConditionID")]
		public int ConditionID { get; set; }

		[XmlElement(ElementName = "Country")]
		public string Country { get; set; }

		[XmlElement(ElementName = "Currency")]
		public string Currency { get; set; }

		[XmlElement(ElementName = "DispatchTimeMax")]
		public int DispatchTimeMax { get; set; } = 1;

		[XmlElement(ElementName = "ListingDuration")]
		public string ListingDuration { get; set; } = "GTC";

		[XmlElement(ElementName = "ListingType")]
		public string ListingType { get; set; } = "FixedPriceItem";

		[XmlElement(ElementName = "PictureDetails")]
		public PictureDetails PictureDetails { get; set; }

		[XmlElement(ElementName = "PostalCode")]
		public int PostalCode { get; set; }

		[XmlElement(ElementName = "ProductListingDetails")]
		public ProductListingDetails ProductListingDetails { get; set; }

		[XmlElement(ElementName = "ItemSpecifics")]
		public ItemSpecifics ItemSpecifics { get; set; }

		[XmlElement(ElementName = "Quantity")]
		public int Quantity { get; set; } = 1;

		[XmlElement(ElementName = "ReturnPolicy")]
		public ReturnPolicy ReturnPolicy { get; set; }

		[XmlElement(ElementName = "ShippingDetails")]
		public ShippingDetails ShippingDetails { get; set; }

		[XmlElement(ElementName = "Site")]
		public string Site { get; set; }
	}
}
