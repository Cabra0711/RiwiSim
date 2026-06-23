namespace LogisticMVP.Models;

public class TariffConfig
{
    public Guid Id { get; set; }
    public decimal PricePerKm { get; set; }
    public decimal PricePerKg { get; set; }
    public decimal UrgentPrioritySurcharge { get; set; }
    public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;
}