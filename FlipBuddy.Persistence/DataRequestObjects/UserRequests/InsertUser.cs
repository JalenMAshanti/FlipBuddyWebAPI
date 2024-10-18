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
						  int subscriptionTier,
						  int flips)
		{
			Guid = guid;
			Username = username;
			FirstName = firstName;
			LastName = lastName;
			Password = password;
			PasswordHash = passwordHash;
			Email = email;
			SubscriptionTier = subscriptionTier;
			Flips = flips;
		}

		public Guid Guid { get; set; }
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public string PasswordHash { get; set; }
		public string Email { get; set; }
		public int SubscriptionTier { get; set; }
		public int Flips { get; set; }

		public object? GetParameters() => this;

		public string GetSql() => "INSERT INTO USERS (Guid, Username, FirstName, LastName, Password, PasswordHash, Email, SubscriptionTier, Flips) VALUES (@Guid, @Username, @FirstName, @LastName, @Password, @PasswordHash, @Email, @SubscriptionTier, @Flips)";
	}
}
