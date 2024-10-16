using FlipBuddy.Persistence.DataRequestObjects.ConditionRequests;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.ConditionTests
{
	public class GetAllConditionsTest : BaseDataRequestTest
	{
		#region Happy Path
		[Fact]
		public async Task GetAllConditions_ShouldReturn_NotNull()
		{
			var rowAffected = await _dataAccess.FetchAsync(new GetAllConditions());

			Assert.NotNull(rowAffected);
		}
		#endregion
	}
}
