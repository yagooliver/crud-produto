using CrudBackend.Domain.Core.Shared.Commands;
using FluentValidation.Results;
using System.Collections.Generic;

namespace CrudBackend.Domain.Core.Commands
{
    public abstract class ComandoGenerico<T> : ICommandResult<T>
    {
        public ComandoGenerico()
        {
            ValidationResult = new ValidationResult();
        }

        protected ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();

        public virtual IList<ValidationFailure> RetornaErros()
        {
            return ValidationResult.Errors;
        }
    }
}
