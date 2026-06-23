namespace LogisticMVP.Models;

public class MaintenanceLog
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public DateTime MaintenanceDate { get; set; }

    public Vehicle? Vehicle { get; set; }
}