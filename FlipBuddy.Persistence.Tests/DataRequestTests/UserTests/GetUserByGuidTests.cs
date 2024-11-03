using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.UserTests
{
    public class GetUserByGuidTests : BaseDataRequestTest
    {
        #region Happy Path
        [Fact]
        public async Task GetUserByGuid_Given_UserExists_ShouldReturn_NotNull()
        {
            //Insert User
            var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

            //Get User(TESTING)
            var rowAffected = await _dataAccess.FetchAsync(new GetUserByGuid(user_DTO.Guid));


            //Test Results
            Assert.Equal(user_DTO.Guid, rowAffected.Guid);
            Assert.Equal(user_DTO.FirstName, rowAffected.FirstName);
            Assert.Equal(user_DTO.LastName, rowAffected.LastName);
            Assert.Equal(user_DTO.Username, rowAffected.Username);
            Assert.Equal(user_DTO.Password, rowAffected.Password);
            Assert.Equal(user_DTO.Email, rowAffected.Email);
            Assert.Equal(user_DTO.SubscriptionTier, rowAffected.SubscriptionTier);

            //Clean up
            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
        }

        #endregion


        #region Bad Paths
        [Fact]
        public async Task GetUserByGuid_Given_UserNotExisting_ShouldReturn_Null()
        {
            //Test Result
            Assert.Null(await _dataAccess.FetchAsync(new GetUserByGuid(Guid.NewGuid())));
        }
        #endregion
    }
}
