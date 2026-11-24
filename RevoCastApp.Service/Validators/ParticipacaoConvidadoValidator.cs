using FluentValidation;
using RevoCastApp.Domain.Entities;

public class ParticipacaoConvidadoValidator : AbstractValidator<ParticipacaoConvidado>
{
    public ParticipacaoConvidadoValidator()
    {
        RuleFor(pc => pc.status)
            .NotEmpty().WithMessage("Informe o status do corte.");

        RuleFor(pc => pc.tema_abordado)
            .NotEmpty().WithMessage("Informe o tema abordado.")
            .MaximumLength(100).WithMessage("O tema abordado deve ter no máximo 100 caracteres.");

        RuleFor(pc => pc.episodio)
            .NotNull().WithMessage("Selecione o episódio deste convidado.");

        RuleFor(pc => pc.convidado)
            .NotNull().WithMessage("Selecione o convidado deste episódio.");
    }
}