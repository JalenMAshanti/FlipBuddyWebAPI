using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DTO;
using FlipBuddy.Tests.Shared.Helpers;

namespace FlipBuddy.Tests.Shared.TestObjects
{
	public class TestProduct
	{
		private static IDataAccess _dataAccess = TestDataAccess.SharedInstance;

		//public static async Task<Products_DTO> InsertAndFetchProductDtoAsync() 
		//{
		//	var userGuid = Guid.NewGuid();	

		//	await _dataAccess.ExecuteAsync(new InsertProduct(
		//													 Guid.NewGuid(),
		//												     userGuid,
		//													 TestString.Random(),
		//													 TestNumber.GetSubTier(),
		//													 decimal.MinValue,
		//													 decimal.MinValue,
		//													 TestString.Random(),
		//													 int.MinValue,
		//													 TestString.Random(),
		//													 TestNumber.GetConditionId()
		//													));

		//	var product = await _dataAccess.FetchAsync(new GetProductsByUserGuid(userGuid));
			
		//	return product;
		//}
	}
}
