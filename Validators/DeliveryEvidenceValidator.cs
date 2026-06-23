using FluentValidation;
using LogisticMVP.Models;

namespace LogisticMVP.Validators;

public class DeliveryEvidenceValidator : AbstractValidator<DeliveryEvidence>
{
    public DeliveryEvidenceValidator()
    {
        RuleFor(e => e.ShipmentId).NotEmpty().WithMessage("La evidencia debe pertenecer a un envío.");
        
        RuleFor(e => e.SecureImageUrl)
            .NotEmpty().WithMessage("La URL o ruta de la fotografía de la guía es obligatoria.");

        
        RuleFor(e => e.Latitude)
            .InclusiveBetween(-90, 90).WithMessage("La latitud debe estar entre -90 y 90 grados.");

        RuleFor(e => e.Longitude)
            .InclusiveBetween(-180, 180).WithMessage("La longitud debe estar entre -180 y 180 grados.");
    }
}