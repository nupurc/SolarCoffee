using System.Collections.Generic;

namespace SolarCoffee.Services.Product
{
    public interface IProductService
    {
        List<Data.Model.Product> GetAllProducts();
        Data.Model.Product GetProduct(int id);
        ServiceResponse<Data.Model.Product> CreateProduct(Data.Model.Product product);
        ServiceResponse<Data.Model.Product> ArchivedProduct(int id);
    }
}
