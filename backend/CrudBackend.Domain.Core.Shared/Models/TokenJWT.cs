namespace CrudBackend.Domain.Core.Shared.Models
{
    public class TokenJWT
    {
        public TokenJWT(bool autenticado, string token)
        {
            Autenticado = autenticado;
            Token = token;
        }

        public bool Autenticado { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; internal set; }
    }
}
