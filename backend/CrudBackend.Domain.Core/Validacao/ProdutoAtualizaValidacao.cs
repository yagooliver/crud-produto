using CrudBackend.Domain.Core.Commands.Produto;
using FluentValidation;

namespace CrudBackend.Domain.Core.Validacao
{
    internal class ProdutoAtualizaValidacao : AbstractValidator<ProdutoAtualizaCommand>
    {
        public ProdutoAtualizaValidacao()
        {
            Inicializa();
        }
        protected void Inicializa()
        {
            RuleFor(x => x.Valor).GreaterThan(0).WithMessage("Valor deve ser informado e deve ser maior que zero");

            RuleFor(x => x.Nome).NotEmpty().NotNull().WithMessage("Nome não pode ser vazio");

            RuleFor(x => x.Id).NotEmpty().NotNull()
                    .WithMessage("O Id deve ser válido");
        }
    }
}
