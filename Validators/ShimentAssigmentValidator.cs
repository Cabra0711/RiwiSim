using FluentValidation;
using LogisticMVP.Models;

namespace LogisticMVP.Validators;

public class ShimentAssigmentValidator : AbstractValidator<ShipmentAssigment>
{
    public ShimentAssigmentValidator()
    {
        RuleFor(a => a.ShipmentId).NotEmpty().WithMessage("Debe seleccionar un envío.");
        RuleFor(a => a.DriverId).NotEmpty().WithMessage("Debe asignar un conductor.");

        RuleFor(a => a.EstimatedStart)
            .NotEmpty().WithMessage("La fecha de inicio estimada es obligatoria.");

        RuleFor(a => a.EstimatedEnd)
            .NotEmpty().WithMessage("La fecha de fin estimada es obligatoria.")
            .GreaterThan(a => a.EstimatedStart).WithMessage("La fecha de fin debe ser mayor a la fecha de inicio.");
    }
}