namespace LogisticMVP.Models;

public class ShipmentAssigment
{
    public Guid Id { get; set; }
    public Guid ShipmentId { get; set; }
    public Guid DriverId { get; set; }
    public DateTime AssignedAt { get; set; }
    
    
    public DateTime EstimatedStart { get; set; }
    public DateTime EstimatedEnd { get; set; }
    public bool IsActive { get; set; } = true;

    public Shipment? Shipment { get; set; }
    public DriverProfile? Driver { get; set; }
}