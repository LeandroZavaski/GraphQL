using GraphQlProject.Models;
using System.Collections.Generic;

namespace GraphQlProject.Interfaces
{
    public interface IProduct
    {
        IEnumerable<Product> GetAllProducts();
        Product AddProduct(Product product);
        Product UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
        Product GetProductById(int id);
    }
}
