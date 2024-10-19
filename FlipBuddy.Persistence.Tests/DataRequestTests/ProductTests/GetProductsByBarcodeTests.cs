using FlipBuddy.Domain.Constants;
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
			var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

			var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

			var product = await _dataAccess.FetchListAsync(new GetProductsByBarcode(product_DTO.BarCode));

			await _dataAccess.ExecuteAsync(new DeleteProductByGuid(product_DTO.Guid));
			await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));

			Assert.Single(product);
		}
		#endregion

		#region Bad Paths
		[Fact]
		public async Task GetProductsByBarcode_Given_BarcodeDoesNotExist_ShouldReturn_EmptyList()
		{
			var upc = TestString.Random(12);

			var products = await _dataAccess.FetchListAsync(new GetProductsByBarcode(upc));

			Assert.Empty(products);
		}
		#endregion
	}
}
