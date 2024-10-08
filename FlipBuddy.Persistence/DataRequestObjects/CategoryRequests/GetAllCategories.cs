using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DTO;

namespace FlipBuddy.Persistence.DataRequestObjects.CategoryRequests
{
	public class GetAllCategories : IDataFetch<Category_DTO>
	{
		public object? GetParameters() => null;

		public string GetSql() => $"SELECT * FROM {DatabaseTable.Categories}";		
	}
}
