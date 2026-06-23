using FluentValidation;
using LogisticMVP.Models;

namespace LogisticMVP.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.FirstName)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(50).WithMessage("El nombre no puede pasar de 50 caracteres.");
        
        RuleFor(u => u.LastName)
            .NotEmpty().WithMessage("El nombre completo no puede estar vacío.")
            .MaximumLength(100).WithMessage("El nombre no puede pasar de 100 caracteres.");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
            .EmailAddress().WithMessage("El formato del correo no es válido.");

        RuleFor(u => u.PasswordHash)
            .NotEmpty().WithMessage("La contraseña no puede estar vacía.")
            .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.");

        RuleFor(u => u.Role)
            .IsInEnum().WithMessage("El rol asignado no es válido.");
    }
}