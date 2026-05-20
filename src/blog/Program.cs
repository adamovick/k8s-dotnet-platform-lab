using blog.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var dbHost =
    Environment.GetEnvironmentVariable("DB_HOST")
    ?? "localhost";

var dbPort =
    Environment.GetEnvironmentVariable("DB_PORT")
    ?? "5432";

var dbName =
    Environment.GetEnvironmentVariable("DB_NAME")
    ?? "postgres";

var dbUser =
    Environment.GetEnvironmentVariable("DB_USER")
    ?? "postgres";

var dbPassword =
    Environment.GetEnvironmentVariable("DB_PASSWORD")
    ?? "kral123";

var connectionString =
    $"Host={dbHost};" +
    $"Port={dbPort};" +
    $"Database={dbName};" +
    $"Username={dbUser};" +
    $"Password={dbPassword}";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();