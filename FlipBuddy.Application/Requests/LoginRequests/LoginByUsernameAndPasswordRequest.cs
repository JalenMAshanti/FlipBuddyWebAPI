using FlipBuddy.Application.Abstraction;

namespace FlipBuddy.Application.Requests.LoginRequests
{
	public class LoginByUsernameAndPasswordRequest : IRequestResponse<LoginByUsernameAndPasswordResponse>
	{
		public LoginByUsernameAndPasswordRequest() { }

		public LoginByUsernameAndPasswordRequest(string username, string password) 
		{
			Username = username;
			Password = password;
		}

		public string Username { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
	}
}
