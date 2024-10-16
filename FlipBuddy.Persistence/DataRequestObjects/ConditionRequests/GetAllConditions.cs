using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DTO;

namespace FlipBuddy.Persistence.DataRequestObjects.ConditionRequests
{
	public class GetAllConditions : IDataFetch<Conditions_DTO>
	{
		public object? GetParameters() => null;

		public string GetSql() => $@"SELECT * FROM {DatabaseTable.Conditions}";
	}
}
