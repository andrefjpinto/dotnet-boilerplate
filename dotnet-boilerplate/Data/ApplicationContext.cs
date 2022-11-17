using Microsoft.EntityFrameworkCore;
using dotnet_boilerplate.Models;

namespace dotnet_boilerplate.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder
            .Entity<Device>()
            .Property(x => x.Id)
            .HasDefaultValueSql("uuid_generate_v4()")
            .IsRequired();

        modelBuilder
            .Entity<Device>()
            .Property(x => x.CreatedAt)
            .HasDefaultValueSql("NOW()")
            .IsRequired();
    }

    public DbSet<Device> Device { get; set; } = default!;
}