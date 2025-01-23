using Microsoft.EntityFrameworkCore;
using PostsApi.Models;

namespace PostsApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Post> Posts { get; set; }
}