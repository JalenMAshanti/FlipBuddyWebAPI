using FlipBuddy.Domain.Models;
using FlipBuddy.Persistence.DTO;

namespace FlipBuddy.Application.Requests.LoginRequests
{
	public class LoginByUsernameAndPasswordResponse
	{
		public LoginByUsernameAndPasswordResponse(Guid_DTO userGuid) => UserGuid = userGuid;
		public Guid_DTO UserGuid { get; set; }
	}
}
