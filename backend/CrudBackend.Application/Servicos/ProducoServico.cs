using CrudBackend.Domain.Core.Entity;
using CrudBackend.Domain.Core.Interface.Repositorios;
using CrudBackend.Domain.Core.Interface.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrudBackend.Application.Servicos
{
    public class ProducoServico : IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProducoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public Produto GetProduto(Guid id) => _produtoRepositorio.GetById(id);

        public IList<Produto> GetProdutos() => _produtoRepositorio.GetAll().ToList();
    }
}
