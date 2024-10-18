using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.DataRequestObjects.LoginRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.LoginTests
{
	public class LoginByUsernameAndPasswordTests : BaseDataRequestTest
	{
		#region Happy Path
		[Fact]
		public async Task LoginByUsernameAndPassword_Given_UsernameAndPasswordCorrect_ShouldReturn_Guid_DTO()
		{
			var username = TestString.Random();
			var password = TestString.Random();
			var guid = Guid.NewGuid();

			var UserGuid = await _dataAccess.ExecuteAsync(new InsertUser(
										guid,
										username,
										TestString.Random(15),
										TestString.Random(),
										password,
										TestString.Random(),
										TestString.Random(),
										TestNumber.GetSubTier(),
										DefaultValues.DefaultFlipsAmount
										));

			var result = await _dataAccess.FetchAsync(new LoginByUsernameAndPassword(username, password));

			Assert.Equal(result.Guid, guid);

			await _dataAccess.ExecuteAsync(new DeleteUserByGuid(guid));
		}
		#endregion

		#region Bad Paths 
		[Fact]
		public async Task LoginByUsernameAndPassword_Given_UsernameDoesNotExist_ShouldReturn_Null()
		{
			var username = TestString.Random();
			var password = TestString.Random();
			var guid = Guid.NewGuid();

			var UserGuid = await _dataAccess.ExecuteAsync(new InsertUser(
										guid,
										username,
										TestString.Random(15),
										TestString.Random(),
										password,
										TestString.Random(),
										TestString.Random(),
										TestNumber.GetSubTier(),
										DefaultValues.DefaultFlipsAmount
										));

			var result = await _dataAccess.FetchAsync(new LoginByUsernameAndPassword(TestString.Random(), password));

			Assert.Null(result);

			await _dataAccess.ExecuteAsync(new DeleteUserByGuid(guid));
		}


		[Fact]
		public async Task LoginByUsernameAndPassword_Given_PasswordIsIncorrect_ShouldReturn_Null()
		{
			var username = TestString.Random();
			var password = TestString.Random();
			var guid = Guid.NewGuid();

			var UserGuid = await _dataAccess.ExecuteAsync(new InsertUser(
										guid,
										username,
										TestString.Random(15),
										TestString.Random(),
										password,
										TestString.Random(),
										TestString.Random(),
										TestNumber.GetSubTier(),
										DefaultValues.DefaultFlipsAmount
										));

			var result = await _dataAccess.FetchAsync(new LoginByUsernameAndPassword(username, TestString.Random()));

			Assert.Null(result);

			await _dataAccess.ExecuteAsync(new DeleteUserByGuid(guid));
		}


		[Fact]
		public async Task LoginByUsernameAndPassword_Given_UserDoesNotExist_ShouldReturn_Null()
		{

			var result = await _dataAccess.FetchAsync(new LoginByUsernameAndPassword(TestString.Random(), TestString.Random()));

			Assert.Null(result);

		}
		#endregion
	}
}
