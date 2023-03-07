using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Skinet.Application.Accounts.Services;
using Skinet.Application.Accounts.Services.Token;
using Skinet.Application.Basket.Services;
using Skinet.Application.Orders.Services;
using Skinet.Application.Products.Services;
using Skinet.Domain;
using Skinet.Domain.Basket.Repository;
using Skinet.Domain.Identity;
using Skinet.Domain.Orders.Repository;
using Skinet.Domain.ProductModel.Repository;
using Skinet.Domain.SeedOfWork;
using Skinet.Infra.Data;
using Skinet.Infra.Data.Context;
using Skinet.Infra.Data.Context.Identity;
using Skinet.Infra.Data.Repository.Orders;
using Skinet.Infra.Repository;
using Skinet.Infra.Repository.Basket;
using Skinet.Infra.Repository.Orders;
using Skinet.Infra.Repository.ProductRepo;
using StackExchange.Redis;
using System.Text;

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
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IDeliveryMethodRepository, DeliveryMethodRepository>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IDeliveryMethodService, DeliveryMethodService>();

        }
        public static void AddLocalUnitOfWork(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>();

            services.AddDbContext<AppIdentityDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddIdentityServices(this IServiceCollection services , IConfiguration configuration)
        {
            var builder = services.AddIdentityCore<AppUser>();

            var tokenKey = configuration["Token:Key"];
            var tokenIssuer = configuration["Token:Issuer"];

            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                        ValidIssuer = tokenIssuer,
                        ValidateIssuer = true,
                        ValidateAudience = false,
                    };
                });

            return services;
        }

    }
}