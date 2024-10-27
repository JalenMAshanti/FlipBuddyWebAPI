namespace FlipBuddy.Domain.Models
{
	public class ProductSpecificValue
	{
		public ProductSpecificValue() { }

		public ProductSpecificValue(int valueId, int specificId, string specificValue)
		{
			ValueId = valueId;
			SpecificId = specificId;
			SpecificValue = specificValue;
		}

		public int ValueId { get; set; }
		public int SpecificId { get; set; }
		public string SpecificValue { get; set; } = string.Empty;
	}
}
