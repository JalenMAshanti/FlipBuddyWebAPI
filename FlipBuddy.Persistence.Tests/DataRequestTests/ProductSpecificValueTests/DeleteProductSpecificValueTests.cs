using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificRequests;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificValueRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Persistence.DTO;
using FlipBuddy.Tests.Shared.Constants;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.ProductSpecificValueTests
{
    public class DeleteProductSpecificValueTests : BaseDataRequestTest
    {
        #region Happy Path
        [Fact]
        public async Task DeleteProductSpecificValue_Given_ProductSpecificIdAndProductSpecificIdIsValid_ShouldReturnOneRowAffected()
        {
            //Insert User
            var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

            //Insert Product
            var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

            //Insert ProductSpecific
            await _dataAccess.ExecuteAsync(new InsertProductSpecific(product_DTO.Guid, TestValues.SpecificName));

            //Get ProductSpecific
            var specifics = await _dataAccess.FetchListAsync(new GetProductSpecifics(product_DTO.Guid));
            ProductSpecifics_DTO productSpecific_DTO = specifics.Where(_ => _.SpecificName == TestValues.SpecificName).First();

            //Insert SpecificValue
            await _dataAccess.ExecuteAsync(new InsertProductSpecificValue(productSpecific_DTO.SpecificId, TestValues.SpecificValue));

            //Get ProductSpecificValue
            var productSpecificValues = await _dataAccess.FetchListAsync(new GetProductSpecificValuesBySpecificId(productSpecific_DTO.SpecificId));
            ProductSpecificValues_DTO productSpecificValues_DTO = productSpecificValues.Where(_ => _.SpecificValue == TestValues.SpecificValue).First();

            //Delete ProductSpecificValue(TESTING)
            var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteProductSpecificValue(productSpecificValues_DTO.ValueId, productSpecificValues_DTO.SpecificId));

            //Test Result
            Assert.Equal(1, rowsAffected);

            //Clean up
            await _dataAccess.ExecuteAsync(new DeleteProductSpecific(productSpecific_DTO.SpecificId, product_DTO.Guid));
            await _dataAccess.ExecuteAsync(new DeleteProductByGuid(product_DTO.Guid));
            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
        }
        #endregion

        #region Bad Paths
        [Fact]
        public async Task DeleteProductSpecificValue_Given_ProductSpecificValueIdIsDoesNotExist_ShouldReturnZeroRowsAffected()
        {
            //Insert User
            var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

            //Insert Product
            var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

            //Insert ProductSpecific
            await _dataAccess.ExecuteAsync(new InsertProductSpecific(product_DTO.Guid, TestValues.SpecificName));

            //Get ProductSpecific
            var specifics = await _dataAccess.FetchListAsync(new GetProductSpecifics(product_DTO.Guid));
            ProductSpecifics_DTO productSpecific_DTO = specifics.Where(_ => _.SpecificName == TestValues.SpecificName).First();

            //Insert SpecificValue
            await _dataAccess.ExecuteAsync(new InsertProductSpecificValue(productSpecific_DTO.SpecificId, TestValues.SpecificValue));

            //Get ProductSpecificValue
            var productSpecificValues = await _dataAccess.FetchListAsync(new GetProductSpecificValuesBySpecificId(productSpecific_DTO.SpecificId));
            ProductSpecificValues_DTO productSpecificValues_DTO = productSpecificValues.Where(_ => _.SpecificValue == TestValues.SpecificValue).First();

            //Delete ProductSpecificValue(TESTING)
            var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteProductSpecificValue(int.MinValue, productSpecificValues_DTO.SpecificId));

            //Test Result
            Assert.Equal(0, rowsAffected);

            //Clean up
            await _dataAccess.ExecuteAsync(new DeleteProductSpecific(productSpecific_DTO.SpecificId, product_DTO.Guid));
            await _dataAccess.ExecuteAsync(new DeleteProductByGuid(product_DTO.Guid));
            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
        }


        [Fact]
        public async Task DeleteProductSpecificValue_Given_ProductSpecificIsDoesNotExist_ShouldReturnZeroRowsAffected()
        {
            //Insert User
            var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

            //Insert Product
            var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

            //Insert ProductSpecific
            await _dataAccess.ExecuteAsync(new InsertProductSpecific(product_DTO.Guid, TestValues.SpecificName));

            //Get ProductSpecific
            var specifics = await _dataAccess.FetchListAsync(new GetProductSpecifics(product_DTO.Guid));
            ProductSpecifics_DTO productSpecific_DTO = specifics.Where(_ => _.SpecificName == TestValues.SpecificName).First();

            //Insert SpecificValue
            await _dataAccess.ExecuteAsync(new InsertProductSpecificValue(productSpecific_DTO.SpecificId, TestValues.SpecificValue));

            //Get ProductSpecificValue
            var productSpecificValues = await _dataAccess.FetchListAsync(new GetProductSpecificValuesBySpecificId(productSpecific_DTO.SpecificId));
            ProductSpecificValues_DTO productSpecificValues_DTO = productSpecificValues.Where(_ => _.SpecificValue == TestValues.SpecificValue).First();

            //Delete ProductSpecificValue(TESTING)
            var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteProductSpecificValue(productSpecificValues_DTO.ValueId, int.MinValue));

            //Test Result
            Assert.Equal(0, rowsAffected);

            //Clean up
            await _dataAccess.ExecuteAsync(new DeleteProductSpecific(productSpecific_DTO.SpecificId, product_DTO.Guid));
            await _dataAccess.ExecuteAsync(new DeleteProductByGuid(product_DTO.Guid));
            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
        }
        #endregion
    }
}
