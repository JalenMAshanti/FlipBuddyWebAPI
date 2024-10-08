using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Models;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.CategoryRequests;

namespace FlipBuddy.Application.Requests.CategoryRequests.GetAllCategoriesList
{
	internal class GetAllCategoriesHandler : DataRequestResponseHandler<GetAllCategoriesRequest, GetAllCategoriesResponse>
	{
		public GetAllCategoriesHandler(IDataAccess dataAccess) : base(dataAccess)
		{
		}

		public override async Task<GetAllCategoriesResponse> GetResponseAsync(GetAllCategoriesRequest request)
		{
			var categories = await _dataAccess.FetchListAsync(new GetAllCategories());

			if (categories.Any()) 
			{
				return new GetAllCategoriesResponse(categories.Select(_ => _.AsDomainCategory()));
			}
		
			return new GetAllCategoriesResponse(Enumerable.Empty<Category>());
		}
	}
}
