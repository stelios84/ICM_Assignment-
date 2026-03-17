using Application.DI;
using Infrastructure.DB.DBContext;
using Infrastructure.DI;
using Microsoft.EntityFrameworkCore;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();
        builder.Services.AddHealthChecks();
        
        builder.Services.AddCors(options=>
        options.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyOrigin()   // allow requests from any domain
                  .AllowAnyHeader()   // allow any HTTP headers
                  .AllowAnyMethod();  // allow GET, POST, PUT, DELETE, etc.
        }));

        var sqlite_connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        
        //EF DB context
        builder.Services.AddDbContext<Infrastructure.DB.DBContext.AppDBContext>(optionx =>
        {
            optionx.UseSqlite(sqlite_connectionString);
        });

        //DB Context Factory
        builder.Services.AddDbContextFactory<Infrastructure.DB.DBContext.AppDBContext>(o =>
        {
            o.UseSqlite(sqlite_connectionString);            
        },ServiceLifetime.Scoped);

        

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure();

        var app = builder.Build();

        using(var sc = app.Services.CreateScope())
        {
            var dbcon = sc.ServiceProvider.GetRequiredService<AppDBContext>();
           // dbcon.Database.EnsureDeleted();
            dbcon.Database.EnsureCreated();

        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            app.UseSwagger();// Enable Swagger JSON endpoint
            app.UseSwaggerUI();

        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.MapHealthChecks("/health");

        app.Run();
    }
}