using FluentValidation;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Service.Validators
{
    public class EquipamentoValidator : AbstractValidator<Equipamento>
    {
        public EquipamentoValidator()
        {
            RuleFor(e => e.nome)
                .NotEmpty().WithMessage("Informe o nome do equipamento.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(e => e.categoria)
                .NotEmpty().WithMessage("Informe a categoria do equipamento.")
                .MaximumLength(50).WithMessage("A categoria deve ter no máximo 50 caracteres.");

            RuleFor(e => e.local_armazenamento)
                .NotEmpty().WithMessage("Informe o local de armazenamento do equipamento.")
                .MaximumLength(50).WithMessage("O local de armazenamento deve ter no máximo 50 caracteres.");

            RuleFor(e => e.patrimonio)
                .NotEmpty().WithMessage("Informe o patrimônio do equipamento.")
                .MaximumLength(50).WithMessage("O patrimônio deve ter no máximo 50 caracteres.");

            RuleFor(e => e.status)
                .NotEmpty().WithMessage("Informe o status do equipamento.")
                .MaximumLength(50).WithMessage("O status deve ter no máximo 50 caracteres.");
        }
    }
}