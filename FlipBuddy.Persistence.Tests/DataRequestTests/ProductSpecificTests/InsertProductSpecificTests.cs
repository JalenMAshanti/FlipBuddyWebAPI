using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificRequests;
using FlipBuddy.Persistence.DTO;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.ProductSpecificTests
{
	public class InsertProductSpecificTests : BaseDataRequestTest
	{
		#region Happy Path
		[Fact]
		public async Task InsertProductSpecific_Given_ProductExists_ShouldReturnOneRowAffected()
		{
			var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

			var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

			var specificName = TestString.Random();

			var rowsAffected = await _dataAccess.ExecuteAsync(new InsertProductSpecific(product_DTO.Guid, specificName));

			var specifics = await _dataAccess.FetchListAsync(new GetProductSpecifics(product_DTO.Guid));

			ProductSpecifics_DTO productSpecific_DTO = specifics.Where(_ => _.SpecificName == specificName).First();

			await _dataAccess.ExecuteAsync(new DeleteProductSpecific(productSpecific_DTO.SpecificId, productSpecific_DTO.ProductGuid));

			Assert.Equal(1, rowsAffected);
		}
		#endregion

		#region Bad Paths
		[Fact]
		public async Task InsertProductSpecific_Given_ProductDoesNotExist_ShouldReturnDataAccessException()
		{
			var specificName = TestString.Random();

			var exception = await Record.ExceptionAsync(async () => await _dataAccess.ExecuteAsync(new InsertProductSpecific(Guid.NewGuid(), specificName)));

			Assert.IsType<DataAccessException>(exception);
		}
		#endregion
	}
}
