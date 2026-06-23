namespace LogisticMVP.Models;

public class Vehicle
{
    public Guid Id { get; set; }
    public string Plate { get; set; } = string.Empty; 
    public string Model { get; set; } = string.Empty;
    public double MaxWeightCapacity { get; set; } 
    public bool IsInMaintenance { get; set; } = false;

    public ICollection<DriverProfile> Drivers { get; set; } = new List<DriverProfile>();
    public ICollection<MaintenanceLog> Maintenances { get; set; } = new List<MaintenanceLog>();
}