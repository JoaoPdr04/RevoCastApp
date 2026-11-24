using FluentValidation;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Service.Validators
{
    public class EtapaProducaoValidator : AbstractValidator<EtapaProducao>
    {
        public EtapaProducaoValidator()
        {
            RuleFor(e => e.etapa)
                .NotEmpty().WithMessage("Informe qual a etapa de produção.")
                .MaximumLength(50).WithMessage("A etapa deve ter no máximo 50 caracteres.");

            RuleFor(e => e.ordem)
                .NotEmpty().WithMessage("Informe o número da ordem da etapa de produção.")
                .InclusiveBetween(1, 100).WithMessage("O número da ordem deve estar entre 1 e 100.");
        }
    }
}