using FluentValidation;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Service.Validators
{
    public class TarefaValidator : AbstractValidator<Tarefa>
    {
        public TarefaValidator()
        {
            RuleFor(t => t.descricao)
                .NotEmpty().WithMessage("Informe a descrição da tarefa.")
                .MaximumLength(150).WithMessage("A descrição deve ter no máximo 150 caracteres.");

            RuleFor(t => t.prazo)
                .NotEmpty().WithMessage("Informe o prazo da tarefa.");

            RuleFor(t => t.status)
                .NotEmpty().WithMessage("Informe o status da tarefa.");

            RuleFor(t => t.episodio)
                .NotNull().WithMessage("Selecione o episódio referente à tarefa.");

            RuleFor(t => t.membro)
                .NotNull().WithMessage("Selecione o membro responsável pela tarefa.");

            RuleFor(t => t.etapa)
                .NotNull().WithMessage("Selecione a etapa de produção.");
        }
    }
}