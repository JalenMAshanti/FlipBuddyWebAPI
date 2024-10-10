using FlipBuddy.Domain.Models;

namespace FlipBuddy.Persistence.DTO
{
	public class Category_DTO
	{
		public int Id { get; set; }
		public string Name { get; set; }= string.Empty;
		public string Bio { get; set; } = string.Empty;
		public int ProductCount { get; set; }
		public Category AsDomainCategory() => new(Id, Name, Bio, ProductCount);
	}
}
