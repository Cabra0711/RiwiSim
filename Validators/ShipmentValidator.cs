using FluentValidation;
using LogisticMVP.Models;

namespace LogisticMVP.Validators;

public class ShipmentValidator : AbstractValidator<Shipment>
{
    public ShipmentValidator()
    {
        RuleFor(s => s.ClientId)
            .NotEmpty().WithMessage("El envío debe estar asociado a un cliente.");

        RuleFor(s => s.RouteId)
            .NotEmpty().WithMessage("El envío debe tener una ruta asignada.");

        RuleFor(s => s.MerchandiseType)
            .NotEmpty().WithMessage("Debe especificar el tipo de mercancía.");

        RuleFor(s => s.EstimatedWeight)
            .GreaterThan(0).WithMessage("El peso estimado debe ser mayor a 0 kg.");

        RuleFor(s => s.EstimatedDeliveryDate)
            .GreaterThan(DateTime.UtcNow).WithMessage("La fecha estimada de entrega debe ser en el futuro.");

        RuleFor(s => s.BaseCost)
            .GreaterThanOrEqualTo(0).WithMessage("El costo base no puede ser negativo.");
    }
}