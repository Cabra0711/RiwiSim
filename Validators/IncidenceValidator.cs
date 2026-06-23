using FluentValidation;
using LogisticMVP.Models;

namespace LogisticMVP.Validators;

public class IncidenceValidator : AbstractValidator<Incidence>
{
    public IncidenceValidator()
    {
        RuleFor(i => i.ShipmentId).NotEmpty().WithMessage("La incidencia debe estar amarrada a un envío.");
        
        RuleFor(i => i.Type)
            .NotEmpty().WithMessage("El tipo de incidencia es obligatorio.");

        RuleFor(i => i.Description)
            .NotEmpty().WithMessage("Debe proporcionar una descripción detallada de la novedad.")
            .MinimumLength(10).WithMessage("La descripción debe ser de al menos 10 caracteres.");
    }
}