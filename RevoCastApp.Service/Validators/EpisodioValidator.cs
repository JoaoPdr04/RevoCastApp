using FluentValidation;
using RevoCastApp.Domain.Entities;
using RevoCastApp.Service.Validators;

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
            .NotEmpty().WithMessage("Informe o formato do episódio.")
            .MaximumLength(50).WithMessage("O formato deve ter no máximo 50 caracteres.");

        RuleFor(e => e.status)
            .NotEmpty().WithMessage("Informe o status do episódio.")
            .MaximumLength(50).WithMessage("O status deve ter no máximo 50 caracteres.");

        RuleFor(e => e.data_gravacao)
            .NotEmpty().WithMessage("Informe a data de gravação.");

        // Avisa o FluentValidation: "Para cada item da lista EquipeEpisodios, rode o EquipeEpisodioValidator"
        RuleForEach(e => e.EquipeEpisodios)
            .SetValidator(new EquipeEpisodioValidator());
    }
}