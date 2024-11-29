namespace FlipBuddy.Domain.Models
{
	public class ProductSpecificsAndSpecificValues
	{
		public ProductSpecificsAndSpecificValues(int specificId, string specificName, List<ProductSpecificValue> values) 
		{
			SpecificId = specificId;
			SpecificName = specificName;
			Values = values;
		}

		public int SpecificId { get; set; }
		public string SpecificName { get; set; } = string.Empty;

		public List<ProductSpecificValue> Values { get; set; }
	}
}
