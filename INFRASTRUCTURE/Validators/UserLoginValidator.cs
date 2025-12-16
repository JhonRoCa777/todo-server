using DOMAIN.Entities;
using FluentValidation;

namespace INFRASTRUCTURE.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLogin>
    {
        public UserLoginValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Campo Obligatorio")
                .MaximumLength(255).WithMessage("Máximo 255 Caracteres")
                .EmailAddress().WithMessage("Formato de email inválido");

            RuleFor(e => e.Password)
                .NotNull().WithMessage("Campo Obligatorio")
                .MinimumLength(8).WithMessage("Mínimo 8 Caracteres")
                .MaximumLength(15).WithMessage("Máximo 30 Caracteres");
        }
    }
}
