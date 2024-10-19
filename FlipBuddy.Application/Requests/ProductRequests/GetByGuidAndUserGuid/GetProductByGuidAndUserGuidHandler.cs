using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Domain.Models;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlippBuddy.Domain.Models;

namespace FlipBuddy.Application.Requests.ProductRequests.GetByGuidAndUserGuid
{
	internal class GetProductByGuidAndUserGuidHandler : DataRequestResponseHandler<GetProductByGuidAndUserGuidRequest, GetProductByGuidAndUserGuidResponse>
	{
		public GetProductByGuidAndUserGuidHandler(IDataAccess dataAccess) : base(dataAccess)
		{
		}

		public async override Task<GetProductByGuidAndUserGuidResponse> GetResponseAsync(GetProductByGuidAndUserGuidRequest request)
		{
			var userDTO = await _dataAccess.FetchAsync(new GetUserByGuid(request.UserGuid));

			if (userDTO == null)
			{
				throw new DoesNotExistException(nameof(User), (request.UserGuid, nameof(request.UserGuid)));
			}

			var productDTO = await _dataAccess.FetchAsync(new GetProductByGuidAndUserGuid(request.UserGuid, request.Guid));

			if (productDTO != null)
			{
				return new GetProductByGuidAndUserGuidResponse(productDTO.AsDomainProduct());
			}

			throw new DoesNotExistException(nameof(Product), (request.Guid, nameof(request.Guid)));
		}
	}
}
