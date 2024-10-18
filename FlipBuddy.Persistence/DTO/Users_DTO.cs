using FlipBuddy.Domain.Models;

namespace FlipBuddy.Persistence.DTO
{
	public class Users_DTO
	{
		public Guid Guid { get; set; }
		public string Username { get; set; } = string.Empty;
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string PasswordHash { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public int SubscriptionTier { get; set; }
		public int Flips { get; set; }

		public User AsDomainUser() => new(Guid, Username, FirstName, LastName, Password, PasswordHash, Email, SubscriptionTier, Flips);
	}
}
