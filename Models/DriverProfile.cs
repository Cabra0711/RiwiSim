namespace LogisticMVP.Models;

public class DriverProfile
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid? CurrentVehicleId { get; set; }
    public bool IsAvailable { get; set; } = true;

    public User? User { get; set; }
    public Vehicle? Vehicle { get; set; }
    public ICollection<ShipmentAssigment> Assignments { get; set; } = new List<ShipmentAssigment>();
}