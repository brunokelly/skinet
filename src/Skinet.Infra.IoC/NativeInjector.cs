using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skinet.Application.Accounts.Services;
using Skinet.Application.Basket.Services;
using Skinet.Application.Products.Services;
using Skinet.Domain;
using Skinet.Domain.Basket.Repository;
using Skinet.Domain.Identity;
using Skinet.Domain.ProductModel.Repository;
using Skinet.Domain.SeedOfWork;
using Skinet.Infra.Data.Context;
using Skinet.Infra.Data.Context.Identity;
using Skinet.Infra.Repository;
using Skinet.Infra.Repository.Basket;
using Skinet.Infra.Repository.ProductRepo;
using StackExchange.Redis;

namespace Skinet.Infra.IoC
{
    public static class NativeInjector
    {
        public static void AddLocalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnectionMultiplexer, ConnectionMultiplexer>(x =>
            {
                var configuration = ConfigurationOptions.Parse("localhost", true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<INotification, Notification>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IProductService, ProductService>();

        }
        public static void AddLocalUnitOfWork(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(x =>
            {
                x.UseSqlite("Data source=skinet.db");
            });

            services.AddDbContext<AppIdentityDbContext>();
        }

        public static IServiceCollection AddIdentityServices(this IServiceCollection services , IConfiguration configuration)
        {
            var builder = services.AddIdentityCore<AppUser>();

            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication();

            return services;
        }

    }
}