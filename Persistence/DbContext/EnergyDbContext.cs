using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.DbContext;

public sealed class EnergyDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public EnergyDbContext(
        DbContextOptions<EnergyDbContext> options)
        : base(options)
    {
    }

    public DbSet<SolarPanel> SolarPanels => Set<SolarPanel>();

    public DbSet<Inverter> Inverters => Set<Inverter>();

    public DbSet<Battery> Batteries => Set<Battery>();

    public DbSet<EnergyMeter> EnergyMeters => Set<EnergyMeter>();

    public DbSet<Device> Devices => Set<Device>();

    public DbSet<WasteAlert> WasteAlerts => Set<WasteAlert>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());

        modelBuilder.Entity<SolarPanel>()
            .HasQueryFilter(entity => !entity.IsDeleted);

        modelBuilder.Entity<Inverter>()
            .HasQueryFilter(entity => !entity.IsDeleted);

        modelBuilder.Entity<Battery>()
            .HasQueryFilter(entity => !entity.IsDeleted);

        modelBuilder.Entity<EnergyMeter>()
            .HasQueryFilter(entity => !entity.IsDeleted);

        modelBuilder.Entity<Device>()
            .HasQueryFilter(entity => !entity.IsDeleted);

        modelBuilder.Entity<WasteAlert>()
            .HasQueryFilter(entity => !entity.IsDeleted);
    }

    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries<BaseEntity>()
            .Where(entry =>
                entry.State == EntityState.Added ||
                entry.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }
            else
            {
                entry.Entity.UpdateTimestamp();
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
