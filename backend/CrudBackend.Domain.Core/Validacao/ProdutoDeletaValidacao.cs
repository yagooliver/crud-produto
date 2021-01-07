using CrudBackend.Domain.Core.Commands.Produto;
using FluentValidation;

namespace CrudBackend.Domain.Core.Validacao
{
    internal class ProdutoDeletaValidacao : AbstractValidator<ProdutoDeletaCommand>
    {
        public ProdutoDeletaValidacao()
        {
            Inicializa();
        }
        protected void Inicializa()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull()
                    .WithMessage("O Id deve ser válido");
        }
    }
}
