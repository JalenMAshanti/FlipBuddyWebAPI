using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DTO;

namespace FlipBuddy.Persistence.DataRequestObjects.LoginRequests
{
	public class LoginByUsernameAndPassword : IDataFetch<Guid_DTO>
	{
		public LoginByUsernameAndPassword(string username, string password) 
		{
			Username = username;
			Password = password;
		}	

		string Username { get; set; } = string.Empty;
		string Password { get; set; } = string.Empty;

		public object? GetParameters() => new { Username, Password };

		public string GetSql() => "SELECT Guid FROM users WHERE Username = @Username AND Password = @Password;";
	}
}
