using FlipBuddy.Domain.Models;

namespace FlipBuddy.Application.Requests.LoginRequests
{
	public class LoginByUsernameAndPasswordResponse
	{
		public LoginByUsernameAndPasswordResponse(User user) => User = user;
		public User User { get; set; }
	}
}
