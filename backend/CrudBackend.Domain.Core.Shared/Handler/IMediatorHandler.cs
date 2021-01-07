using CrudBackend.Domain.Core.Shared.Commands;
using System.Threading.Tasks;

namespace CrudBackend.Domain.Core.Shared.Handler
{
    public interface IMediatorHandler
    {
        Task<TResult> ExecutaComando<TResult>(ICommandResult<TResult> comando);
        Task EnviaEvento<T>(T evento) where T : class;
    }
}
