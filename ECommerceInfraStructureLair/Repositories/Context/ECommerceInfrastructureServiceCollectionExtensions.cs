using ECommerceInfraStructureLair;
using ECommerceUseCaseLair;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System;



namespace ECommerceInfraStructureLair
{
    public static class ECommerceInfrastructureServiceCollectionExtensions
    {




        public static IServiceCollection AddECommerceInfrastructure(
            this IServiceCollection services , IConfiguration config)
        {

            var connectionString = config.GetConnectionString("EcommerceConnection")
            ?? throw new InvalidOperationException("Missing 'EcommerceConnection' connection string.");


            services.AddSingleton<IDbConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

            services.AddDbContext<ECommerceDbContext>(options =>
                options.UseSqlServer(connectionString));





            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemsRepository, OrderItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPermissionsRepository, PermissionRepository>();
  

            return services;

        }




        public static void EnsureECommerceDatabaseCreated(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();
            dbContext.Database.Migrate(); // or EnsureCreated() if you have no migrations
        }



    }
}