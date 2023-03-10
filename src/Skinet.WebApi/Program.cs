using Microsoft.EntityFrameworkCore;
using Skinet.Infra.Data.Context;
using Skinet.Infra.Data.SeedData;
using Skinet.WebApi.Middleware;
using Skinet.Infra.IoC;
using Microsoft.Extensions.FileProviders;
using Skinet.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Skinet.Infra.Data.Context.Identity;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddLocalServices(builder.Configuration);
builder.Services.AddLocalUnitOfWork(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SkiNet API", Version = "v1" });

    var seucritySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Auth Bearer Scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", seucritySchema);
    var securityRequirement = new OpenApiSecurityRequirement
    {
        {
            seucritySchema,
            new[] {"Bearer"}
        }
    };

    c.AddSecurityRequirement(securityRequirement);
});

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

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseStaticFiles(
     new StaticFileOptions
     {
         FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")
                    ),
         RequestPath = "/wwwroot/images"
     }
);
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    StoreContextMigrations(services);
    IdentityContextMigrations(services);
}

app.Run();

async void StoreContextMigrations(IServiceProvider services)
{
    try
    {
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        var context = services.GetRequiredService<StoreContext>();
        var result = await context.Database.GetPendingMigrationsAsync();
        if (result.Any())
        {
            await context.Database.MigrateAsync();
        }
        await StoreContextSeed.SeedAsync(context, loggerFactory, builder.Configuration);
    }
    catch (Exception ex)
    {
        throw new Exception(ex.Message);
    }
}

async void IdentityContextMigrations(IServiceProvider services)
{
    try
    {
        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var identityContext = services.GetRequiredService<AppIdentityDbContext>();
        var result = await identityContext.Database.GetPendingMigrationsAsync();
        if (result.Any())
        {
            await identityContext.Database.MigrateAsync();
        }
        await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
    }
    catch (Exception ex)
    {
        throw new Exception(ex.Message);
    }
}