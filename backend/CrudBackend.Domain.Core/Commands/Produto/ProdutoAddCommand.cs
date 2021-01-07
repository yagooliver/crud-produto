using CrudBackend.Domain.Core.Validacao;
using System;

namespace CrudBackend.Domain.Core.Commands.Produto
{
    public class ProdutoAddCommand : ProdutoCommand<Guid>
    {
        public override bool IsValid()
        {
            ValidationResult = new ProdutoValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
