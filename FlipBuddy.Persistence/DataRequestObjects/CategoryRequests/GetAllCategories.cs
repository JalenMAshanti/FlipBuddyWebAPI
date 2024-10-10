using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DTO;

namespace FlipBuddy.Persistence.DataRequestObjects.CategoryRequests
{
	public class GetAllCategories : IDataFetch<Category_DTO>
	{
		public object? GetParameters() => null;

		public string GetSql() => $@"SELECT {DatabaseTable.Categories}.*, COUNT({DatabaseTable.Products}.CategoryId) AS ProductCount	
									FROM {DatabaseTable.Categories}
									LEFT JOIN {DatabaseTable.Products} 
									ON {DatabaseTable.Products}.CategoryId = {DatabaseTable.Categories}.Id
									GROUP BY {DatabaseTable.Categories}.Id;";

	}
}
