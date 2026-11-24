using FluentValidation;
using RevoCastApp.Domain.Entities;

public class UsoEquipamentoValidator : AbstractValidator<UsoEquipamento>
{
    public UsoEquipamentoValidator()
    {
        RuleFor(ue => ue.observacao)
            .MaximumLength(150).WithMessage("A observação deve ter no máximo 150 caracteres.");

        RuleFor(ue => ue.episodio)
            .NotNull().WithMessage("Selecione o episódio deste uso de equipamento.");

        RuleFor(ue => ue.equipamento)
            .NotNull().WithMessage("Selecione o equipamento utilizado.");
    }
}