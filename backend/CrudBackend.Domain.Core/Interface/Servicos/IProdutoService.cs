using CrudBackend.Domain.Core.Entity;
using System;
using System.Collections.Generic;

namespace CrudBackend.Domain.Core.Interface.Servicos
{
    public interface IProdutoService
    {
        IList<Produto> GetProdutos();
        Produto GetProduto(Guid id);

    }
}
