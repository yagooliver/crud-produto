using System;

namespace CrudBackend.Domain.Core.Shared.EntityBase
{
    public class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
        }
        public Guid Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
}
