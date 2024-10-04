namespace FlipBuddy.Persistence.Abstractions
{
    public interface IDataRequest
    {
        public string GetSql();

        public object? GetParameters();
    }

    public interface IDataExecute : IDataRequest { }

    public interface IDataFetch<TResponse> : IDataRequest { }
}
