namespace FlipBuddy.Domain.Models
{
	public class Barcode
	{
		public Barcode() { }

		public Barcode(string barcodeStream) => BarcodeStream = barcodeStream;

		public string? BarcodeStream { get; set; }
	}
}
