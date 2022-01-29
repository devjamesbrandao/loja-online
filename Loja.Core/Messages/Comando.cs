using FluentValidation.Results;
using MediatR;

namespace Loja.Core.Message
{
    public abstract class Comando : Mensagem, IRequest<bool>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Comando()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}