using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.ProductTests
{
    public class UpdateProductByGuidAndUserGuidTests : BaseDataRequestTest
    {
        #region Happy Path
        [Fact]
        public async Task UpdateProduct_Given_GuidsExist_ShouldEqualUpdateProduct()
        {
            var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

            var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);


            var UpdateProductRequest = new UpdateProductByGuidAndUserGuid(
                                                        product_DTO.Guid,
                                                        user_DTO.Guid,
                                                        TestString.Random(),
                                                        TestNumber.GetSubTier(),
                                                        DefaultValues.TestPurchasePrice,
                                                        DefaultValues.TestPurchasePrice * 2,
                                                        TestString.Random(),
                                                        DefaultValues.DefaultQuantity,
                                                        DefaultValues.DefaultCurrency,
                                                        TestNumber.GetConditionId(),
                                                        DefaultValues.DefaultBarcode
                                                        );


            await _dataAccess.ExecuteAsync(UpdateProductRequest);

            var updatedProduct_DTO = await _dataAccess.FetchAsync(new GetProductByGuidAndUserGuid(user_DTO.Guid, product_DTO.Guid));

            Assert.Equal(UpdateProductRequest.Title, updatedProduct_DTO.Title);
            Assert.Equal(UpdateProductRequest.Description, updatedProduct_DTO.Description);
            Assert.Equal(UpdateProductRequest.CategoryId, updatedProduct_DTO.CategoryId);
            Assert.Equal(UpdateProductRequest.ConditionId, updatedProduct_DTO.ConditionId);
            Assert.Equal(UpdateProductRequest.Currency, updatedProduct_DTO.Currency);
            Assert.Equal(UpdateProductRequest.BarCode, updatedProduct_DTO.BarCode);
            Assert.Equal(UpdateProductRequest.PurchasedPrice, updatedProduct_DTO.PurchasedPrice);
            Assert.Equal(UpdateProductRequest.SellPrice, updatedProduct_DTO.SellPrice);
            Assert.Equal(UpdateProductRequest.Quantity, updatedProduct_DTO.Quantity);
            Assert.Equal(UpdateProductRequest.Guid, updatedProduct_DTO.Guid);
            Assert.Equal(UpdateProductRequest.UserGuid, updatedProduct_DTO.UserGuid);

            await _dataAccess.ExecuteAsync(new DeleteProductByGuid(product_DTO.Guid));
            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));

        }
        #endregion


        #region Bad Paths
        [Fact]
        public async Task UpdateProduct_Given_ProductGuidDoesNotExist_ShouldReturn0RowsAffected()
        {
            var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

            var UpdateProductRequest = new UpdateProductByGuidAndUserGuid(
                                                        Guid.NewGuid(),
                                                        user_DTO.Guid,
                                                        TestString.Random(),
                                                        TestNumber.GetSubTier(),
                                                        DefaultValues.TestPurchasePrice,
                                                        DefaultValues.TestPurchasePrice * 2,
                                                        TestString.Random(),
                                                        DefaultValues.DefaultQuantity,
                                                        DefaultValues.DefaultCurrency,
                                                        TestNumber.GetConditionId(),
                                                        DefaultValues.DefaultBarcode
                                                        );

            var rowsAffected = await _dataAccess.ExecuteAsync(UpdateProductRequest);

            Assert.Equal(0, rowsAffected);

            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
        }

        [Fact]
        public async Task UpdateProduct_Given_UserGuidDoesNotExist_ShouldReturn0RowsAffected()
        {

            var UpdateProductRequest = new UpdateProductByGuidAndUserGuid(
                                                        Guid.NewGuid(),
                                                        Guid.NewGuid(),
                                                        TestString.Random(),
                                                        TestNumber.GetSubTier(),
                                                        DefaultValues.TestPurchasePrice,
                                                        DefaultValues.TestPurchasePrice * 2,
                                                        TestString.Random(),
                                                        DefaultValues.DefaultQuantity,
                                                        DefaultValues.DefaultCurrency,
                                                        TestNumber.GetConditionId(),
                                                        DefaultValues.DefaultBarcode
                                                        );

            var rowsAffected = await _dataAccess.ExecuteAsync(UpdateProductRequest);

            Assert.Equal(0, rowsAffected);
        }
        #endregion
    }
}
