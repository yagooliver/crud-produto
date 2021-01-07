using MediatR;

namespace CrudBackend.Domain.Core.Shared.Commands
{
    public interface ICommandResult<T> : IRequest<T>
    {
        bool IsValid();
    }
}
