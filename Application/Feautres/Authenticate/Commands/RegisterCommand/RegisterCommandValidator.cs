using FluentValidation;
namespace Application.Feautres.Authenticate.Commands.RegisterCommand
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p => p.Nombre)
              .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
              .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.UserName)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(10).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Password)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(15).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}
