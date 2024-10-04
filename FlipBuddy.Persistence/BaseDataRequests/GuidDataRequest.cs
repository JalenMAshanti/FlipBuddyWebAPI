using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Persistence.BaseDataRequests
{
	public abstract class GuidDataRequest : IDataRequest
	{
		public Guid Guid { get; set; }

		public GuidDataRequest(Guid guid) => Guid = guid;

		public object? GetParameters() => new { Guid };

		public abstract string GetSql();
	}
}
