using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DTO;

namespace FlipBuddy.Persistence.DataRequestObjects.ProductSpecificValueRequests
{
    public class GetProductSpecificValuesBySpecificId : IDataFetch<ProductSpecificValues_DTO>
    {
        public GetProductSpecificValuesBySpecificId( int specificId) 
        {
            SpecificId = specificId;
        }

        public int SpecificId { get; set; }

        public object? GetParameters() => this;

        public string GetSql() => $@"SELECT * FROM {DatabaseTable.ProductsSpecificValues} WHERE SpecificId = @SpecificId";
    }
}
