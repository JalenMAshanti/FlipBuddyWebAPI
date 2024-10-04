using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.UserTests
{
	public class InsertUserTests : BaseDataRequestTest
	{
		#region Happy Path
		[Fact]
		public async Task InsertUser_Given_InputIsValid_ShouldReturn_OneRowAffected()
		{
			var guid = Guid.NewGuid();

			var rowsaffected = await _dataAccess.ExecuteAsync(new InsertUser(
										guid,
										TestString.Random(),
										TestString.Random(15),
										TestString.Random(),
										TestString.Random(),
										TestString.Random(),
										TestString.Random(),
										TestNumber.GetSubTier()
										));

			await _dataAccess.ExecuteAsync(new DeleteUserByGuid(guid));

			Assert.Equal(1, rowsaffected);
		}
		#endregion


		#region Bad Paths
		[Fact]
		public async Task InsertUser_Given_GuidAlreadyTaken_ShouldThrowDataAccessException()
		{
			var guid = Guid.NewGuid();

			var insertUser = new InsertUser(
											guid,
											TestString.Random(),
											TestString.Random(15),
											TestString.Random(),
											TestString.Random(),
											TestString.Random(),
											TestString.Random(),
											TestNumber.GetSubTier()
											);
		

			var insertUserWithSameGuid = new InsertUser(
														guid,
														TestString.Random(),
														TestString.Random(15),
														TestString.Random(),
														TestString.Random(),
														TestString.Random(),
														TestString.Random(),
														TestNumber.GetSubTier()
														);

			//inserting first user
			await _dataAccess.ExecuteAsync(insertUser);

			//recording exception from inserting second user with same guid
			var exception = await Record.ExceptionAsync(async ()=> await _dataAccess.ExecuteAsync(insertUserWithSameGuid));

			Assert.IsType<DataAccessException>(exception);

			await _dataAccess.ExecuteAsync(new DeleteUserByGuid(guid));
		}


		[Fact]
		public async Task InsertUser_Given_UsernameAlreadyTaken_ShouldThrowDataAccessException()
		{
			var guid = Guid.NewGuid();
			var username = TestString.Random();	
			

			var insertUser = new InsertUser(
											guid,
											username,
											TestString.Random(15),
											TestString.Random(),
											TestString.Random(),
											TestString.Random(),
											TestString.Random(),
											TestNumber.GetSubTier()
											);


			var insertUserWithSameUsername = new InsertUser(
														Guid.NewGuid(),
														username,
														TestString.Random(15),
														TestString.Random(),
														TestString.Random(),
														TestString.Random(),
														TestString.Random(),
														TestNumber.GetSubTier()
														);

			//inserting first user
			await _dataAccess.ExecuteAsync(insertUser);

			//recording exception from inserting second user with same username
			var exception = await Record.ExceptionAsync(async () => await _dataAccess.ExecuteAsync(insertUserWithSameUsername));

			Assert.IsType<DataAccessException>(exception);

			await _dataAccess.ExecuteAsync(new DeleteUserByGuid(guid));
		}

		#endregion
	}
}
