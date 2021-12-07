using GraphQL;
using GraphQL.Types;
using GraphQlProject.Interfaces;
using GraphQlProject.Models;
using GraphQlProject.Type;

namespace GraphQlProject.Mutation
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProduct productService)
        {
            Field<ProductType>("createProduct",
                arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context =>
                {
                    var productObject = context.GetArgument<Product>("product");

                    return productService.AddProduct(productObject);
                });

            Field<ProductType>("updateProduct",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" },
                                              new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context =>
                {
                    var productId = context.GetArgument<int>("id");
                    var productObject = context.GetArgument<Product>("product");

                    return productService.UpdateProduct(productId, productObject);
                });

            Field<StringGraphType>("deleteProduct",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var productId = context.GetArgument<int>("id");
                    productService.DeleteProduct(productId);

                    return "The product against the: " + productId + "has been deleted!";
                });
        }
    }
}
