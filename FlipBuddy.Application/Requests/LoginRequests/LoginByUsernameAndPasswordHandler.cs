using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Domain.Models;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.LoginRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;

namespace FlipBuddy.Application.Requests.LoginRequests
{
	internal class LoginByUsernameAndPasswordHandler : DataRequestResponseHandler<LoginByUsernameAndPasswordRequest, LoginByUsernameAndPasswordResponse>
	{
		public LoginByUsernameAndPasswordHandler(IDataAccess dataAccess) : base(dataAccess) { }

		public override async Task<LoginByUsernameAndPasswordResponse> GetResponseAsync(LoginByUsernameAndPasswordRequest request)
		{
			try
			{
				var UserGuid = await _dataAccess.FetchAsync(new LoginByUsernameAndPassword(request.Username,
																					   request.Password));
				if (UserGuid == null) 
				{
					throw new DoesNotExistException(nameof(User), (request.Username, nameof(request.Username)));
				}

				return new LoginByUsernameAndPasswordResponse(UserGuid);
			}
			catch(DataAccessException ex) 
			{
				throw new OperationFailedException();
			}
		}
	}
}
