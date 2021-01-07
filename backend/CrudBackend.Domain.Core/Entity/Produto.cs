using CrudBackend.Domain.Core.Shared.EntityBase;

namespace CrudBackend.Domain.Core.Entity
{
    public class Produto : EntityBase
    {
        public Produto(string nome, decimal valor, string imagem)
        {
            Nome = nome;
            Valor = valor;
            Imagem = imagem;
        }

        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }

        public void AtualizaCampos(string nome, decimal valor, string imagem)
        {
            Nome = nome;
            Valor = valor;
            Imagem = imagem;
        }
    }
}
