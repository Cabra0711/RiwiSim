using FluentValidation;
using LogisticMVP.Models;

namespace LogisticMVP.Validators;

public class VehicleValidator : AbstractValidator<Vehicle>
{
    public VehicleValidator()
    {
        RuleFor(v => v.Plate)
            .NotEmpty().WithMessage("La placa del vehículo es obligatoria.")
            .Matches(@"^[A-Z]{3}[0-9]{3}$|^[A-Z]{3}[0-9]{2}[A-Z]$") // Formato carro o moto colombiana
            .WithMessage("La placa debe tener un formato válido (Ej: ABC123 o ABC12D).");

        RuleFor(v => v.Model)
            .NotEmpty().WithMessage("El modelo/línea del vehículo es obligatorio.");

        RuleFor(v => v.MaxWeightCapacity)
            .GreaterThan(0).WithMessage("La capacidad de carga máxima debe ser mayor a 0 kg.");
    }
}