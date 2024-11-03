using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.ProductTests
{
    public class GetProductsByBarcodeTests : BaseDataRequestTest
    {
        #region Happy Path
        [Fact]
        public async Task GetProductsByBarcode_Given_BarcodeExists_ShouldReturn_ListOfProducts()
        {
            //Insert User
            var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

            //Insert Product
            var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

            //Get Product(TESTING)
            var product = await _dataAccess.FetchListAsync(new GetProductsByBarcode(product_DTO.BarCode));

            //Test Result
            Assert.Single(product);

            //Clean up
            await _dataAccess.ExecuteAsync(new DeleteProductByGuid(product_DTO.Guid));
            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
        }
        #endregion

        #region Bad Paths
        [Fact]
        public async Task GetProductsByBarcode_Given_BarcodeDoesNotExist_ShouldReturn_EmptyList()
        {
            //Get Product(TESTING)
            var products = await _dataAccess.FetchListAsync(new GetProductsByBarcode(TestString.Random(12)));

            //Test Result
            Assert.Empty(products);
        }
        #endregion
    }
}
