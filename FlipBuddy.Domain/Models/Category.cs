namespace FlipBuddy.Domain.Models
{
	public class Category
	{
		public  Category() { }

		public Category(int categoryId,
						string name,
						string bio
						) 
		{
			CategoryId = categoryId;
			Name = name;
			Bio = bio;	
		}
		public int CategoryId { get; set; }
		public string? Name { get; set; }
		public string? Bio { get; set; }
	}
}
