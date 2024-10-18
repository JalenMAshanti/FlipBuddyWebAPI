using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Persistence.DTO;
using FlipBuddy.Tests.Shared.Helpers;

namespace FlipBuddy.Tests.Shared.TestObjects
{
	public static class TestUser
	{
		private static IDataAccess _dataAccess = TestDataAccess.SharedInstance;

		public static async Task<Users_DTO> InsertAndFetchUsersDtoAsync() 
		{
			var guid = Guid.NewGuid();

			var insertUserRequest = new InsertUser(
										guid, 
										TestString.Random(),
										TestString.Random(15),
										TestString.Random(),
										TestString.Random(),
										TestString.Random(),
										TestString.Random(),
										TestNumber.GetSubTier(),
										DefaultValues.DefaultFlipsAmount
										);

			await _dataAccess.ExecuteAsync(insertUserRequest);

			var result = await _dataAccess.FetchAsync(new GetUserByGuid(guid));

			return result!;
		}
	}
}
