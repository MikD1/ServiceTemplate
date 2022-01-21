using Microsoft.EntityFrameworkCore;
using ServiceTemplate.Model;

namespace ServiceTemplate.Application;

public sealed class ServiceDbContext : DbContext
{
    public ServiceDbContext(DbContextOptions<ServiceDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<ExampleModel> ExampleModels => Set<ExampleModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ExampleModel>();
    }
}