using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.ProductTests
{
    public class GetProductsByUserGuidTests : BaseDataRequestTest
    {
        #region Happy Path
        [Fact]
        public async Task GetProductsByUserGuid_Given_UserExists_ShouldReturn_List()
        {
            //Insert User
            var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

            //Insert Product
            var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

            //Get Products(TESTING)
            var product = await _dataAccess.FetchListAsync(new GetProductsByUserGuid(user_DTO.Guid));

            //Test Result
            Assert.Single(product);

            //Clean up
            await _dataAccess.ExecuteAsync(new DeleteProductByGuid(product_DTO.Guid));
            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
        }
        #endregion

        #region Bad Paths
        [Fact]
        public async Task GetProductsByUserGuid_Given_UserDoesNotExist_ShouldReturnNull()
        {
            //Get Products(TESTING)
            var rowsAffected = await _dataAccess.FetchListAsync(new GetProductsByUserGuid(Guid.NewGuid()));

            //Test Result
            Assert.Empty(rowsAffected);
        }
        #endregion
    }
}
