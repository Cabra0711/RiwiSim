namespace LogisticMVP.Models;

public class DeliveryEvidence
{
    public Guid Id { get; set; }
    public Guid ShipmentId { get; set; }
    public string SecureImageUrl { get; set; } = string.Empty; 
    public DateTime CapturedAt { get; set; }
    
  
    public double Latitude { get; set; }
    public double Longitude { get; set; }

   
    public string? AiExtractedReceiverName { get; set; }
    public string? AiExtractedIdNumber { get; set; }
    public DateTime? AiExtractedDate { get; set; }
    public string? AiExtractedTrackingNumber { get; set; }
    
    public bool IsAiApproved { get; set; }
    public string? AiValidationNotes { get; set; }

    public Shipment? Shipment { get; set; }
}