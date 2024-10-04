namespace FlipBuddy.Domain.Models.APIResponses
{
	// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
	public class Item
	{
		public string? ean { get; set; }
		public string? title { get; set; }
		public string? upc { get; set; }
		public string? gtin { get; set; }
		public string? asin { get; set; }
		public string? description { get; set; }
		public string? brand { get; set; }
		public string? model { get; set; }
		public string? dimension { get; set; }
		public string? weight { get; set; }
		public string? category { get; set; }
		public string? currency { get; set; }
		public double? lowest_recorded_price { get; set; }
		public decimal highest_recorded_price { get; set; }
		public List<string>? images { get; set; }
		public List<Offer>? offers { get; set; }
	}

	public class Offer
	{
		public string? merchant { get; set; }
		public string? domain { get; set; }
		public string? title { get; set; }
		public string? currency { get; set; }
		public decimal? list_price { get; set; }
		public decimal price { get; set; }
		public string? shipping { get; set; }
		public string? condition { get; set; }
		public string? availability { get; set; }
		public string? link { get; set; }
		public int updated_t { get; set; }
	}

	public class UpciteLookupAPIResponse
	{
		public string? code { get; set; }
		public decimal? total { get; set; }
		public int? offset { get; set; }
		public List<Item>? items { get; set; }
	}


}
