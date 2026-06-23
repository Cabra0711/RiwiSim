using LogisticMVP.Enums;

namespace LogisticMVP.Models;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public string? Token { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DriverProfile? DriverProfile { get; set; }
    public ICollection<ClientFavorite>? Favorites { get; set; }
    public ICollection<Shipment>? ClientShipments { get; set; }
}