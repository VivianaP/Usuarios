using FluentValidation;

namespace Application.Feautres.Usuarios.Commands.UpdateUsuarioCommand
{
    public class UpdateUsuarioCommandValidator : AbstractValidator<UpdateUsuarioCommand>
    {
        public UpdateUsuarioCommandValidator()
        {
            RuleFor(p => p.Nombre)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                  .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Email)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .EmailAddress().WithMessage("{PropertyName} debe ser una direccion de email valida")
               .MaximumLength(250).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Telefono)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .Matches(@"^\d{4}-\d{4}$").WithMessage("{PropertyName} debe cumplir el formato 0000-0000")
               .MaximumLength(9).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Username)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}
