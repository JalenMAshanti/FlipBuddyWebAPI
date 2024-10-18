using System.Diagnostics.CodeAnalysis;

namespace FlipBuddy.Domain.Models
{
	public class User
	{
		public User() { }

		public User(Guid guid,
					string userName,
					string firstName,
					string lastName,
					string password,
					string passwordHash,
					string email,
					int subscriptionTier,
					int flips
					)
		{
			Guid = guid;
			Username = userName;
			FirstName = firstName;
			LastName = lastName;
			Password = password;
			PasswordHash = passwordHash;
			Email = email;
			SubscriptionTier = subscriptionTier;
			Flips = flips;
			
		}

		public Guid? Guid { get; set; }
		public string? Username { get; set; } = string.Empty;
		public string? FirstName { get; set; } = string.Empty;
		public string? LastName { get; set; } = string.Empty;
		public string? Password { get; set; } = string.Empty;
		public string? PasswordHash { get; set; } = string.Empty;
		public string? Email { get; set; } = string.Empty;
		public int SubscriptionTier { get; set; }
		public int Flips { get; set; }
	}
}
