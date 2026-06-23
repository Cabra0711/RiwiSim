using LogisticMVP.Enums;

namespace LogisticMVP.Models;

public class Shipment
{
    public Guid Id { get; set; }
    public string TrackingNumber { get; set; } = string.Empty;
    public Guid ClientId { get; set; }
    public Guid RouteId { get; set; }
    
    public string MerchandiseType { get; set; } = string.Empty;
    public double EstimatedWeight { get; set; }
    public string? Notes { get; set; }
    
    public ShipmentStatus Status { get; set; } = ShipmentStatus.Created;
    public ShipmentPriority Priority { get; set; } = ShipmentPriority.Medium;
    
    
    public decimal BaseCost { get; set; }
    public decimal PrioritySurcharge { get; set; } 
    public decimal TotalCost => BaseCost + PrioritySurcharge;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime EstimatedDeliveryDate { get; set; }

    public User? Client { get; set; }
    public Route? Route { get; set; }
    public ICollection<ShipmentAssigment> Assignments { get; set; } = new List<ShipmentAssigment>();
    public ICollection<ShipmentEventLog> EventLogs { get; set; } = new List<ShipmentEventLog>();
    public ICollection<Incidence> Incidences { get; set; } = new List<Incidence>();
    public DeliveryEvidence? Evidence { get; set; }
}