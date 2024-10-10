namespace FlipBuddy.Domain.Models
{
	public class Category
	{
		public  Category() { }

		public Category(int id,
						string name,
						string bio,
						int productCount) 
		{
			Id = id;
			Name = name;
			Bio = bio;	
			ProductCount = productCount;
		}
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Bio { get; set; }
		public int ProductCount { get; set; }
	}
}
