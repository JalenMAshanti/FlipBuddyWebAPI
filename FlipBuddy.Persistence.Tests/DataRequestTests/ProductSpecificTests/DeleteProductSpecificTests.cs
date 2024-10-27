using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Persistence.DTO;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.ProductSpecificTests
{
	public class DeleteProductSpecificTests : BaseDataRequestTest
	{
		#region Happy Path
		[Fact]
		public async Task DeleteProductSpecific_Given_ProductExistsAndIdIsCorrect_ShouldReturnOneRowAffected()
		{
			var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

			var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

			var specificName = TestString.Random();

			await _dataAccess.ExecuteAsync(new InsertProductSpecific(product_DTO.Guid, specificName));

			var specifics = await _dataAccess.FetchListAsync(new GetProductSpecifics(product_DTO.Guid));

			ProductSpecifics_DTO productSpecific_DTO = specifics.Where(_ => _.SpecificName == specificName).First();

			var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteProductSpecific(productSpecific_DTO.SpecificId, productSpecific_DTO.ProductGuid));

			Assert.Equal(1, rowsAffected);

			await _dataAccess.ExecuteAsync(new DeleteProductByGuid(product_DTO.Guid));
			await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
		}
		#endregion

		#region Bad Paths
		[Fact]
		public async Task DeleteProductSpecific_Given_ProductGuidDoesNotExist_ShouldReturnZeroRowsAffected()
		{
			var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

			var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

			var specificName = TestString.Random();

			await _dataAccess.ExecuteAsync(new InsertProductSpecific(product_DTO.Guid, specificName));

			var specifics = await _dataAccess.FetchListAsync(new GetProductSpecifics(product_DTO.Guid));

			ProductSpecifics_DTO productSpecific_DTO = specifics.Where(_ => _.SpecificName == specificName).First();

			var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteProductSpecific(productSpecific_DTO.SpecificId, Guid.NewGuid()));

			Assert.Equal(0, rowsAffected);
			await _dataAccess.ExecuteAsync(new DeleteProductByGuid(product_DTO.Guid));
			await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
		}

		[Fact]
		public async Task DeleteProductSpecific_Given_SpecificIdDoesNotExist_ShouldReturnZeroRowsAffected()
		{
			var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

			var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

			var specificName = TestString.Random();

			await _dataAccess.ExecuteAsync(new InsertProductSpecific(product_DTO.Guid, specificName));

			var specifics = await _dataAccess.FetchListAsync(new GetProductSpecifics(product_DTO.Guid));

			ProductSpecifics_DTO productSpecific_DTO = specifics.Where(_ => _.SpecificName == specificName).First();

			var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteProductSpecific(int.MaxValue, productSpecific_DTO.ProductGuid));

			Assert.Equal(0, rowsAffected);
			await _dataAccess.ExecuteAsync(new DeleteProductByGuid(product_DTO.Guid));
			await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
		}

		[Fact]
		public async Task DeleteProductSpecific_Given_SpecificIdAndProductGuidDoesNotExist_ShouldReturnZeroRowsAffected()
		{
			var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteProductSpecific(int.MaxValue, Guid.NewGuid()));

			Assert.Equal(0, rowsAffected);	
		}
		#endregion
	}
}
