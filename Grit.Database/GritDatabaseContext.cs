using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Grit.Database.Entities;

namespace Grit.Database;

public class GritDbContext : DbContext
{
    public DbSet<Habit>? Habits { get; set; }

    private readonly IConfiguration _configuration;

    public GritDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) 
        => options.UseNpgsql(_configuration.GetConnectionString("Postgres"));

    protected override void OnModelCreating(ModelBuilder modelBuilder) => SeedData.Seed(modelBuilder);
}