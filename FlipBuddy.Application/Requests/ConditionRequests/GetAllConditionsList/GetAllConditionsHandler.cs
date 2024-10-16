using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Models;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.ConditionRequests;

namespace FlipBuddy.Application.Requests.ConditionRequests.GetAllConditionsList
{
	internal class GetAllConditionsHandler : DataRequestResponseHandler<GetAllConditionsRequest, GetAllConditionsResponse>
	{
		public GetAllConditionsHandler(IDataAccess dataAccess) : base(dataAccess)
		{
		}

		public override async Task<GetAllConditionsResponse> GetResponseAsync(GetAllConditionsRequest request)
		{
			var conditions = await _dataAccess.FetchListAsync(new GetAllConditions());

			if (conditions.Any()) 
			{
				return new GetAllConditionsResponse(conditions.Select(_ => _.AsDomainCondition()));
			}

			return new GetAllConditionsResponse(Enumerable.Empty<Condition>());
		}
	}
}
