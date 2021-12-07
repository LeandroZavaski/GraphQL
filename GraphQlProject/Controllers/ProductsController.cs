using GraphQlProject.Interfaces;
using GraphQlProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GraphQlProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _product;
        public ProductsController(IProduct product)
        {
            _product = product;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _product.GetAllProducts();
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return _product.GetProductById(id);
        }

        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            _product.AddProduct(product);
            return product;
        }

        [HttpPut("{id}")]
        public Product Put(int id, [FromBody] Product product)
        {
            _product.UpdateProduct(id, product);
            return product;
        }

        // POST: ProductsController/Delete/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _product.DeleteProduct(id);
        }
    }
}
