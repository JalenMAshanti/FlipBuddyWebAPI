using FlipBuddy.Domain.Constants;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Tests.Shared.Constants;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.ProductTests
{
    public class InsertProductTests : BaseDataRequestTest
    {
        #region Happy Path
        [Fact]
        public async Task InsertProduct_Given_InputIsValid_ShouldReturnOneRowAffected()
        {
            //Insert User
            var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

            //Insert Product(TESTING)
            var productGuid = Guid.NewGuid();

            var insertProductRequest = new InsertProduct(
                                                        productGuid,
                                                        user_DTO.Guid,
                                                        TestValues.ProductTitle,
                                                        TestNumber.GetSubTier(),
                                                        DefaultValues.TestPurchasePrice,
                                                        DefaultValues.TestPurchasePrice * 2,
                                                        TestString.Random(),
                                                        int.MinValue,
                                                        TestString.Random(),
                                                        TestNumber.GetConditionId()
                                                        );

            var rowsAffected = await _dataAccess.ExecuteAsync(insertProductRequest);

            //Test Result
            Assert.Equal(1, rowsAffected);

            //Clean up
            await _dataAccess.ExecuteAsync(new DeleteProductByGuid(productGuid));
            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));


        }
        #endregion

        #region Bad Paths
        [Fact]
        public async Task InsertProduct_Given_GuidAlreadyTacked_ShouldThrowDataAccessException()
        {
            //Insert User
            var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

            // InsertProduct(TESTING) 
            var productGuid = Guid.NewGuid();

            var insertProductRequest = new InsertProduct(
                                                        productGuid,
                                                        user_DTO.Guid,
                                                        TestValues.ProductTitle,
                                                        TestNumber.GetSubTier(),
                                                        DefaultValues.TestPurchasePrice,
                                                        DefaultValues.TestPurchasePrice * 2,
                                                        TestString.Random(),
                                                        int.MinValue,
                                                        TestString.Random(),
                                                        TestNumber.GetConditionId()
                                                        );

            var insertProductRequestSameGuid = new InsertProduct(
                                                        productGuid,
                                                        user_DTO.Guid,
                                                        TestValues.ProductTitle,
                                                        TestNumber.GetSubTier(),
                                                        DefaultValues.TestPurchasePrice,
                                                        DefaultValues.TestPurchasePrice * 2,
                                                        TestString.Random(),
                                                        int.MinValue,
                                                        TestString.Random(),
                                                        TestNumber.GetConditionId()
                                                        );

            await _dataAccess.ExecuteAsync(insertProductRequest);

            //Insert Second Product(TESTING)
            var exception = await Record.ExceptionAsync(async () => await _dataAccess.ExecuteAsync(insertProductRequestSameGuid));

            //Test Result
            Assert.IsType<DataAccessException>(exception);

            //Clean up
            await _dataAccess.ExecuteAsync(new DeleteProductByGuid(productGuid));
            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
        }
        #endregion
    }
}
