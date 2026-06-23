namespace LogisticMVP.Models;

public class ClientFavorite
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty; 
    public string Address { get; set; } = string.Empty;
    public string? ContactName { get; set; }

    public User? User { get; set; }
}