using System.Collections.Generic;
namespace ProductManager;

public interface IProductRepository
{
    List<Product> GetByCategory(string category);
}