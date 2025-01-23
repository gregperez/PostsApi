using Microsoft.EntityFrameworkCore;
using PostsApi.Data;
using PostsApi.Services;

var builder = WebApplication.CreateBuilder(args);

var conStrBuilder = new SqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("Posts"));
conStrBuilder.Password = builder.Configuration["DbPassword"];
var connection = conStrBuilder.ConnectionString;

// Configuración de Entity Framework y servicios
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<PostService>();
builder.Services.AddControllers();

var app = builder.Build();

// Middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();