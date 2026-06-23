using LogisticMVP.Models;
using Microsoft.EntityFrameworkCore;
using Route = LogisticMVP.Models.Route;

namespace LogisticMVP.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<DriverProfile>()
            .HasOne(d => d.User)
            .WithOne(u => u.DriverProfile)
            .HasForeignKey<DriverProfile>(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);

     
        modelBuilder.Entity<Shipment>()
            .HasOne(s => s.Client)
            .WithMany(u => u.ClientShipments)
            .HasForeignKey(s => s.ClientId)
            .OnDelete(DeleteBehavior.Restrict); 

     
        modelBuilder.Entity<DeliveryEvidence>()
            .HasOne(e => e.Shipment)
            .WithOne(s => s.Evidence)
            .HasForeignKey<DeliveryEvidence>(e => e.ShipmentId)
            .OnDelete(DeleteBehavior.Cascade);

       
        modelBuilder.Entity<MaintenanceLog>()
            .Property(m => m.Cost)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Shipment>()
            .Property(s => s.BaseCost)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Shipment>()
            .Property(s => s.PrioritySurcharge)
            .HasPrecision(18, 2);

        modelBuilder.Entity<TariffConfig>()
            .Property(t => t.PricePerKm)
            .HasPrecision(18, 2);

        modelBuilder.Entity<TariffConfig>()
            .Property(t => t.PricePerKg)
            .HasPrecision(18, 2);

        modelBuilder.Entity<TariffConfig>()
            .Property(t => t.UrgentPrioritySurcharge)
            .HasPrecision(18, 2);

      
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Vehicle>()
            .HasIndex(v => v.Plate)
            .IsUnique();

        modelBuilder.Entity<Shipment>()
            .HasIndex(s => s.TrackingNumber)
            .IsUnique();
    }
    
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<DriverProfile> DriverProfiles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Incidence> Incidences { get; set; }
    public DbSet<ClientFavorite> ClientFavorites { get; set; }
    public DbSet<MaintenanceLog> MaintenanceLogs { get; set; }
    public DbSet<TariffConfig> TariffConfigs { get; set; }
    public DbSet<ShipmentAssigment> ShipmentAssigments { get; set; }
    public DbSet<ShipmentEventLog> ShipmentEventLogs { get; set; }
    public DbSet<DeliveryEvidence> DeliveryEvidences { get; set; }
}