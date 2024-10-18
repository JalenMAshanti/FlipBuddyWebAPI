using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Constants;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Domain.Models;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;

namespace FlipBuddy.Application.Requests.UserRequests.Insert
{
	internal class InsertUserHandler : DataRequestHandler<InsertUserRequest>
	{
		public InsertUserHandler(IDataAccess dataAccess) : base(dataAccess)
		{
		}

		public override async Task ExecuteRequestAsync(InsertUserRequest request)
		{
			try
			{
				var rowsAffected = await _dataAccess.ExecuteAsync(new InsertUser(request.Guid,
																				  request.Username,
																				  request.FirstName,
																				  request.LastName,
																				  request.Password,
																				  request.Password,
																				  request.Email!,
																				  DefaultValues.DefaultSubscriptionTier,
																				  DefaultValues.DefaultFlipsAmount
																				));
				if (rowsAffected <= 0)
				{
					throw new OperationFailedException();
				}

			}
			catch (DataAccessException ex)
			{
				if (ex.Message.StartsWith("Duplicate entry"))
				{
					if (ex.Message.EndsWith("'users.PRIMARY'"))
					{
						throw new AlreadyExistsException(nameof(User), (request.Guid, nameof(request.Guid)));
					}

					if (ex.Message.EndsWith("'users.Username_UNIQUE'"))
					{
						throw new AlreadyExistsException(nameof(User), (request.Username, nameof(request.Username)));
					}

					if (ex.Message.EndsWith("'users.unique_email'"))
					{
						throw new AlreadyExistsException(nameof(User), (request.Email, nameof(request.Email)));
					}
				}

				throw new OperationFailedException();
			}
		}
	}
}
