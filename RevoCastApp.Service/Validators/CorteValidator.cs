using FluentValidation;
using RevoCastApp.Domain.Entities;

public class CorteValidator : AbstractValidator<Corte>
{
    public CorteValidator()
    {
        RuleFor(c => c.titulo)
            .NotEmpty().WithMessage("Informe o título do corte.")
            .MaximumLength(150).WithMessage("O título deve ter no máximo 150 caracteres.");

        RuleFor(c => c.status)
            .NotEmpty().WithMessage("Informe o status do corte.")
            .MaximumLength(50).WithMessage("O status deve ter no máximo 50 caracteres.");

        // Só verifica se o usuário escolheu um item nos ComboBoxes da tela!
        RuleFor(c => c.episodio)
            .NotNull().WithMessage("Selecione o episódio deste corte.");

        RuleFor(c => c.membro)
            .NotNull().WithMessage("Selecione o membro responsável pelo corte.");
    }
}