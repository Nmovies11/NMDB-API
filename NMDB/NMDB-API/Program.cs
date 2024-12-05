
using NMDB_BLL.Interfaces.Repositories;
using NMDB_DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NMDB_BLL.Services;
using Azure.Identity;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<IShowRepository, ShowRepository>();
builder.Services.AddScoped<ShowService>();

if (builder.Environment.IsProduction())
{
    var keyVaultURL = builder.Configuration.GetValue<string>("KeyVault:KeyvaultURL");
    var credential = new ManagedIdentityCredential();

    var secretClient = new SecretClient(new Uri(keyVaultURL), credential);

    builder.Configuration.AddAzureKeyVault(secretClient, new AzureKeyVaultConfigurationOptions());

    var connectionString = builder.Configuration["NMDBDatabaseURLProd"];

    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("Database connection string 'DatabaseURLProd' is missing.");
    }

    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySql(
            connectionString,
            new MySqlServerVersion(new Version(8, 0, 39)),
            mysqlOptions => mysqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null
        )

        );
    });
}

if(builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySql(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
        );
    });
}





var app = builder.Build();



    app.UseSwagger();
    app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();  
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
