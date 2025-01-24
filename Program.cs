using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PostsApi.Data;
using PostsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Entity Framework y servicios
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<PostService>();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Posts API",
        Description = "An ASP.NET Core Web API for managing Posts items"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
app.UseHttpsRedirection();
app.UseCors(b =>
    b
        .WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader());
app.UseAuthorization();
app.MapControllers();

app.Run();