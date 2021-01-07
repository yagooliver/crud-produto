using CrudBackend.Domain.Core.Validacao;
using System;

namespace CrudBackend.Domain.Core.Commands.Produto
{
    public class ProdutoDeletaCommand : ProdutoCommand<bool>
    {
        public Guid Id { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ProdutoDeletaValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
