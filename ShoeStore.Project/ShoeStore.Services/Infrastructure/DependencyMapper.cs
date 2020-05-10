using Microsoft.Data.SqlClient.Server;
using Microsoft.Extensions.DependencyInjection;
using ShoeStore.Data;
using ShoeStore.Services.Addresses;
using ShoeStore.Services.Brands;
using ShoeStore.Services.Products;
using ShoeStore.Services.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Services.Infrastructure
{
   public static class DependencyMapper
    {
        public static IServiceCollection MapDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ShoeStoreContext>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IAddressService, AddressService>()
                .AddScoped<IBrandService, BrandService>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IUserService, UserService>();

            return serviceCollection;
        }
    }
}
