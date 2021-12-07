using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using GraphQlProject.Data;
using GraphQlProject.Interfaces;
using GraphQlProject.Mutation;
using GraphQlProject.Query;
using GraphQlProject.Schema;
using GraphQlProject.Services;
using GraphQlProject.Type;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQlProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IProduct, ProductService>();
            services.AddScoped<ProductType>();
            services.AddScoped<ProductQuery>();
            services.AddScoped<ProductMutation>();
            services.AddScoped<ISchema, ProductSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;

            }).AddSystemTextJson();

            services.AddDbContext<GraphQLDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("GrapQlDbConnection"));
            });

            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
            //    {
            //        Title = "Place Info Service API",
            //        Version = "v2",
            //        Description = "Sample service for Learner",
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GraphQLDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            dbContext.Database.EnsureCreated();
            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            //app.UseSwagger();

            //app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "PlaceInfo Services"));
        }
    }
}
