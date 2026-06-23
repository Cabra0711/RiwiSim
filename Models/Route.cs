namespace LogisticMVP.Models;

public class Route
{
    public Guid Id { get; set; }
    public string OriginAddress { get; set; } = string.Empty;
    public string DestinationAddress { get; set; } = string.Empty;
    public double EstimatedDistance { get; set; } 
    public TimeSpan EstimatedDuration { get; set; }
}