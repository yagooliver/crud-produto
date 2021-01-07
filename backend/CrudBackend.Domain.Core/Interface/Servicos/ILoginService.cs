using CrudBackend.Domain.Core.Shared.Models;

namespace CrudBackend.Domain.Core.Interface.Servicos
{
    public interface ILoginService
    {
        TokenJWT RetornaToken(string login);
    }
}
