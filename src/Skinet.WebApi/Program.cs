using Microsoft.EntityFrameworkCore;
using Skinet.Domain;
using Skinet.Domain.ProductModel.Repository;
using Skinet.Domain.SeedOfWork;
using Skinet.Infra;
using Skinet.Infra.Data.Context;
using Skinet.Infra.Data.SeedData;
using Skinet.Infra.Repository;
using Skinet.Infra.Repository.ProductRepo;
using Skinet.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
ConfigureServices(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    var context = services.GetRequiredService<StoreContext>();
    var result = await context.Database.GetPendingMigrationsAsync();
    if (result.Any())
    {
        await context.Database.MigrateAsync();
    }
    await StoreContextSeed.SeedAsync(context, loggerFactory);

}

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<StoreContext>();
    services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
    services.AddScoped<INotification, Notification>();
    services.AddScoped<IProductRepository, ProductRepository>();
}

