using DOMAIN.Entities;
using FluentValidation;

namespace INFRASTRUCTURE.Validators
{
    public class TodoRequestValidator : AbstractValidator<TodoRequest>
    {
        public TodoRequestValidator()
        {
            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("Campo Obligatorio")
                .MaximumLength(255).WithMessage("Máximo 255 Caracteres");
        }
    }
}
