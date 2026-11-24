using FluentValidation;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Service.Validators
{
    public class MembroValidator : AbstractValidator<Membro>
    {
        public MembroValidator()
        {
            RuleFor(m => m.nome)
                .NotEmpty().WithMessage("Informe o nome do membro.")
                .MaximumLength(150).WithMessage("O nome deve ter no máximo 150 caracteres.");

            RuleFor(m => m.curso)
                .NotEmpty().WithMessage("Informe o curso do membro.")
                .MaximumLength(100).WithMessage("O curso deve ter no máximo 100 caracteres.");

            RuleFor(m => m.prontuario)
                .NotEmpty().WithMessage("Informe o prontuário (ex: BI3033988).")
                .MaximumLength(20).WithMessage("O prontuário deve ter no máximo 20 caracteres.");
        }
    }
}