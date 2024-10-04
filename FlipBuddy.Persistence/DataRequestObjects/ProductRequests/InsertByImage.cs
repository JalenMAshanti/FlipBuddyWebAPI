using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Persistence.DataRequestObjects.ProductRequests
{
	public class InsertByImage : IDataExecute
	{
		public InsertByImage() { }

		public object? GetParameters() => this;


		public string GetSql() => $@"
									INSERT INTO {DatabaseTable.Products} 
									(Guid, UserGuid, Title, CategoryId, PurchasedPrice, SellPrice, Description, Quantity, Currency, ConditionId) 
									VALUES 
									(@Guid, @UserGuid, @Title, @CategoryId, @PurchasedPrice, @SellPrice, @Description, @Quantity, @Currency, @ConditionId
								  );";

	}
}
