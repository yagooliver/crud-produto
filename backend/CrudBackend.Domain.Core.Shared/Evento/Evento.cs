using MediatR;
using System;

namespace CrudBackend.Domain.Core.Shared.Evento
{
    public abstract class Evento : IRequest<bool>, INotification
    {
        public DateTime DateAndTime { get; private set; }
        protected Evento()
        {
            DateAndTime = DateTime.Now;
        }

    }
}
