using Microsoft.EntityFrameworkCore;
using Skinet.Infra.Data.Context;
using Skinet.Infra.Data.SeedData;
using Skinet.WebApi.Middleware;
using Skinet.Infra.IoC;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLocalServices(builder.Configuration);
builder.Services.AddLocalUnitOfWork(builder.Configuration);

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

app.UseCors(x => x.AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials());

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
app.UseStaticFiles(
     new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine (Directory.GetCurrentDirectory(), "wwwroot")
                    ),
        RequestPath = "/wwwroot/images"
    }
);
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

