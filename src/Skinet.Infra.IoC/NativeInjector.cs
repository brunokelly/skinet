﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skinet.Domain;
using Skinet.Domain.ProductModel.Repository;
using Skinet.Domain.SeedOfWork;
using Skinet.Infra.Data.Context;
using Skinet.Infra.Data.Context.Identity;
using Skinet.Infra.Repository;
using Skinet.Infra.Repository.ProductRepo;

namespace Skinet.Infra.IoC
{
    public static class NativeInjector
    {
        public static void AddLocalServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<INotification, Notification>();
            services.AddScoped<IProductRepository, ProductRepository>();
            
        }
        public static void AddLocalUnitOfWork(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(x =>
            {
                x.UseSqlite("Data source=skinet.db");
            });

            services.AddDbContext<AppIdentityDbContext>();
        }

    }
}