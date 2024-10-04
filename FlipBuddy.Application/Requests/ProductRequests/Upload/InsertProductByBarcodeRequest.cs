using FlipBuddy.Application.Abstraction;
using Microsoft.AspNetCore.Http;

namespace FlipBuddy.Application.Requests.ProductRequests.Upload
{
	public class InsertProductByBarcodeRequest : IRequest
	{
		public InsertProductByBarcodeRequest() { }

		public InsertProductByBarcodeRequest(IFormFile image, Guid guid, Guid userGuid)
		{
			Image = image;
			Guid = guid;
			UserGuid = userGuid;
		}

		public IFormFile? Image { get; set; }	

		public Guid Guid { get; set; }

		public Guid UserGuid { get; set; }
	}
}
