using System.Collections.Generic;
using Insurance.Infrastructure.Domain;

namespace Insurance.Infrastructure
{
    public interface IDataAccessService
    {
        List<ProductType> GetProductTypes();
        List<Product> GetProducts(List<int> productID);
    }
}
