using FlipBuddy.Domain.Models;

namespace FlipBuddy.Persistence.DTO
{
	public class Category_DTO
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }= string.Empty;
		public string Bio { get; set; } = string.Empty;
		public Category AsDomainCategory() => new(CategoryId, Name, Bio);
	}
}
