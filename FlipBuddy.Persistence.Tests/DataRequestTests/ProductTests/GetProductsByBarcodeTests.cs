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

			var productGuid = Guid.NewGuid();

			var upc = TestString.Random(12);

			await _dataAccess.ExecuteAsync(new InsertProduct(
												productGuid,
												user_DTO.Guid,
												TestString.Random(),
												TestNumber.GetSubTier(),
												DefaultValues.TestPurchasePrice,								
												DefaultValues.TestPurchasePrice * 2,
												TestString.Random(),
												int.MinValue,
												TestString.Random(),
												TestNumber.GetConditionId(),
												upc
											   ));


			var product = await _dataAccess.FetchListAsync(new GetProductsByBarcode(upc));

			await _dataAccess.ExecuteAsync(new DeleteProductByGuid(productGuid));
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
