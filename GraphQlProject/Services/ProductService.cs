using GraphQlProject.Data;
using GraphQlProject.Interfaces;
using GraphQlProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphQlProject.Services
{
    public class ProductService : IProduct
    {
        private readonly GraphQLDbContext _dbContext;
        public ProductService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            var productObject = _dbContext.Products.Find(id);

            _dbContext.Products.Remove(productObject);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefault(s => s.Id == id);
        }

        public Product UpdateProduct(int id, Product product)
        {
            var productObject = _dbContext.Products.Find(id);
            productObject.Name = product.Name;
            productObject.Price = product.Price;

            _dbContext.SaveChanges();

            return product;
        }
    }
}
