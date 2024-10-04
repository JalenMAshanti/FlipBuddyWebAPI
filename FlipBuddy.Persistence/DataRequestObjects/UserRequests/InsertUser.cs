using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Persistence.DataRequestObjects.UserRequests
{
	public class InsertUser : IDataExecute
	{
		public InsertUser(Guid guid,
						  string username,
						  string firstName,
						  string lastName,
						  string password,
						  string passwordHash,
						  string email,
						  int subscriptionTier)
		{
			Guid = guid;
			Username = username;
			FirstName = firstName;
			LastName = lastName;
			Password = password;
			PasswordHash = passwordHash;
			Email = email;
			SubscriptionTier = subscriptionTier;
		}

		public Guid Guid { get; set; }
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public string PasswordHash { get; set; }
		public string Email { get; set; }
		public int SubscriptionTier { get; set; }

		public object? GetParameters() => this;

		public string GetSql() => "INSERT INTO USERS (Guid, Username, FirstName, LastName, Password, PasswordHash, Email, SubscriptionTier) VALUES (@Guid, @Username, @FirstName, @LastName, @Password, @PasswordHash, @Email, @SubscriptionTier)";
	}
}
