namespace CrudBackend.Domain.Core.Commands.Produto
{
    public class ProdutoCommand<T> : ComandoGenerico<T>
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }

        public override bool IsValid()
        {
            return false;
        }
    }
}
