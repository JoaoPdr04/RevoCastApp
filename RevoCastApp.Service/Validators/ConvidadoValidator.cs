using FluentValidation;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Service.Validators
{
    public class ConvidadoValidator : AbstractValidator<Convidado>
    {
        public ConvidadoValidator()
        {
            RuleFor(e => e.nome)
                .NotEmpty().WithMessage("Informe o nome do convidado.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(e => e.email)
                .NotEmpty().WithMessage("Informe o email do convidado.")
                .MaximumLength(100).WithMessage("O email deve ter no máximo 100 caracteres.");

            RuleFor(e => e.especialidade)
                .NotEmpty().WithMessage("Informe a especialidade do convidado.")
                .MaximumLength(50).WithMessage("A especialidade deve ter no máximo 50 caracteres.");

            RuleFor(e => e.vinculo_institucional)
                .NotEmpty().WithMessage("Informe o vínculo institucional do convidado.")
                .MaximumLength(100).WithMessage("O vínculo institucional deve ter no máximo 100 caracteres.");
        }
    }
}