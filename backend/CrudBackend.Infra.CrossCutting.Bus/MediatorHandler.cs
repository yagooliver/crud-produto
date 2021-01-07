using CrudBackend.Domain.Core.Shared.Commands;
using CrudBackend.Domain.Core.Shared.Handler;
using MediatR;
using System.Threading.Tasks;

namespace CrudBackend.Infra.CrossCutting.Bus
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task EnviaEvento<T>(T evento) where T : class =>  await _mediator.Publish(evento);
        public async Task<TResult> ExecutaComando<TResult>(ICommandResult<TResult> comando) => await _mediator.Send(comando);
    }
}
