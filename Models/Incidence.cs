namespace LogisticMVP.Models;

public class Incidence
{
    public Guid Id { get; set; }
    public Guid ShipmentId { get; set; }
    public string Type { get; set; } = string.Empty; 
    public string Description { get; set; } = string.Empty;
    public DateTime ReportedAt { get; set; } = DateTime.UtcNow;
    public bool RequiresRouteRecalculation { get; set; }

    public Shipment? Shipment { get; set; }
}