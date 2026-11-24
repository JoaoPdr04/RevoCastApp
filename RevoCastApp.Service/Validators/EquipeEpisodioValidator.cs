using FluentValidation;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Service.Validators
{
    public class EquipeEpisodioValidator : AbstractValidator<EquipeEpisodio>
    {
        public EquipeEpisodioValidator()
        {
            RuleFor(ee => ee.funcao)
                .NotEmpty().WithMessage("Informe a função do membro no episódio.")
                .MaximumLength(50).WithMessage("A função deve ter no máximo 50 caracteres.");

            RuleFor(ee => ee.membro)
                .NotNull().WithMessage("Selecione o membro da equipe.");
        }
    }

    public class EpisodioValidator : AbstractValidator<Episodio>
    {
        public EpisodioValidator()
        {
            RuleFor(e => e.numero_ep)
                .GreaterThan(0).WithMessage("O número do episódio deve ser maior que zero.");

            RuleFor(e => e.titulo)
                .NotEmpty().WithMessage("Informe o título do episódio.")
                .MaximumLength(150).WithMessage("O título deve ter no máximo 150 caracteres.");

            RuleFor(e => e.formato)
                .NotEmpty().WithMessage("Informe o formato do episódio.");

            RuleFor(e => e.status)
                .NotEmpty().WithMessage("Informe o status do episódio.");

            RuleFor(e => e.data_gravacao)
                .NotEmpty().WithMessage("Informe a data de gravação.");

            // Valida cada item adicionado na lista de equipe usando o EquipeEpisodioValidator
            RuleForEach(e => e.EquipeEpisodios)
                .SetValidator(new EquipeEpisodioValidator());
        }
    }
}