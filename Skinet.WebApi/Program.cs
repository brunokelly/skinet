using Skinet.Domain.Product;
using Skinet.Domain.SeedOfWork;
using Skinet.Infra.Data.Context;
using Skinet.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
ConfigureServices(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<StoreContext>();
    services.AddScoped<INotification, Notification>();
    services.AddScoped<IProductRepository, ProductRepository>();
}
