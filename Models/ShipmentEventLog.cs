using LogisticMVP.Enums;

namespace LogisticMVP.Models;

public class ShipmentEventLog
{
    public Guid Id { get; set; }
    public Guid ShipmentId { get; set; }
    public ShipmentStatus StatusChangedTo { get; set; }
    public string Description { get; set; } = string.Empty; 
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public Shipment? Shipment { get; set; }
}