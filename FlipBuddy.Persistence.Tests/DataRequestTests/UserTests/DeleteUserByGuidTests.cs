using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.UserTests
{
	public class DeleteUserByGuidTests : BaseDataRequestTest
	{
		#region Happy Path
		[Fact]
		public async Task DeleteUserByGuid_Given_UserExists_ShouldReturn_NotNull()
		{
			var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

			var rowsaffected = await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));

			Assert.Equal(1, rowsaffected);
		}
		#endregion

		
		#region Bad Paths
		[Fact]
		public async Task DeleteUserByGuid_Given_UserDoesNotExist_ShouldReturn_ZeroRowsEffected()
		{
			var rowsaffected = await _dataAccess.ExecuteAsync(new DeleteUserByGuid(Guid.NewGuid()));

			Assert.Equal(0, rowsaffected);
		}
		#endregion
	}
}
