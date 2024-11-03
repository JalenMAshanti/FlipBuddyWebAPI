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
            //Insert User
            var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

            //Delete User(TESTING)
            var rowsaffected = await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));

            //Test Result
            Assert.Equal(1, rowsaffected);

            //Clean up
        }
        #endregion


        #region Bad Paths
        [Fact]
        public async Task DeleteUserByGuid_Given_UserDoesNotExist_ShouldReturn_ZeroRowsEffected()
        {
            //Insert User
            var rowsaffected = await _dataAccess.ExecuteAsync(new DeleteUserByGuid(Guid.NewGuid()));

            //Test Result
            Assert.Equal(0, rowsaffected);
        }
        #endregion
    }
}
