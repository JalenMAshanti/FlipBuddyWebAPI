using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Domain.Models;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;

namespace FlipBuddy.Application.Requests.ProductRequests.Get
{
	internal class GetProductsByUserGuidHandler : DataRequestResponseHandler<GetProductsByUserGuidRequest, GetProductsByUserGuidResponse>
	{
		public GetProductsByUserGuidHandler(IDataAccess dataAccess) : base(dataAccess) { }

		public override async Task<GetProductsByUserGuidResponse> GetResponseAsync(GetProductsByUserGuidRequest request)
		{
			var userDTO = await _dataAccess.FetchAsync(new GetUserByGuid(request.UserGuid));

			if (userDTO == null)
			{
				throw new DoesNotExistException(nameof(User), (request.UserGuid, nameof(request.UserGuid)));
			}

			var products = await _dataAccess.FetchListAsync(new GetProductsByUserGuid(request.UserGuid));

			return new GetProductsByUserGuidResponse(products);
		}
	}
}
