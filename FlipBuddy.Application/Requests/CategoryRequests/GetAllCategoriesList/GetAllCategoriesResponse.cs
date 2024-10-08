using FlipBuddy.Domain.Models;

namespace FlipBuddy.Application.Requests.CategoryRequests.GetAllCategoriesList
{
    public class GetAllCategoriesResponse
    {
        public GetAllCategoriesResponse(IEnumerable<Category> categories) => Categories = categories;

        public IEnumerable<Category> Categories { get; set; }
    }
}
