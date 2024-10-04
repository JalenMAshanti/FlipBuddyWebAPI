using FlipBuddy.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using ZXing;
using ZXing.Windows.Compatibility;

namespace FlipBuddy.Application.Helpers
{
	public class BarcodeScanner
	{
		public static string ReadBarcode(IFormFile request)
		{
			BarcodeReader barcodeReader = new BarcodeReader();

			var stream = request.OpenReadStream();

			var bitmap = (Bitmap)Image.FromStream(stream);

			LuminanceSource source = new BitmapLuminanceSource(bitmap);

			var result = barcodeReader.Decode(source);

			if (result == null)
			{
				throw new OperationFailedException();
			}

			var format = result.BarcodeFormat.ToString();

			var code = result.Text;

			return code;
		}
	}
}
