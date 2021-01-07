using CrudBackend.Domain.Core.Entity;
using CrudBackend.Domain.Core.Interface.Repositorios;
using CrudBackend.Infra.Data.Context;

namespace CrudBackend.Infra.Data.Repositorios
{
    public class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(CrudContext db) : base(db) { }
    }
}
