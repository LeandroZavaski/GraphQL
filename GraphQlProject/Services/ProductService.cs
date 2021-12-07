using GraphQlProject.Interfaces;
using GraphQlProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphQlProject.Services
{
    public class ProductService : IProduct
    {
        public ProductService()
        {

        }

        private static readonly List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 0,
                Name = "Coffe",
                Price = 10
            },
            new Product
            {
                Id = 1,
                Name = "Tea",
                Price = 15
            }
        };

        public Product AddProduct(Product product)
        {
            products.Add(product);
            return product;
        }

        public void DeleteProduct(int id)
        {
            products.RemoveAt(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(s => s.Id == id);
        }

        public Product UpdateProduct(int id, Product product)
        {
            products[id-1] = product;
            return product;
        }
    }
}
