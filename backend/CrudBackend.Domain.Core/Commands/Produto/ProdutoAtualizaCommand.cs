using CrudBackend.Domain.Core.Validacao;
using System;

namespace CrudBackend.Domain.Core.Commands.Produto
{
    public class ProdutoAtualizaCommand : ProdutoCommand<bool>
    {
        public Guid Id { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ProdutoAtualizaValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
