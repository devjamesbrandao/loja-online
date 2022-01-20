using MediatR;

namespace Loja.Core.Message
{
    public abstract class Evento : Mensagem, INotification
    {
        public DateTime Data { get; private set; }

        protected Evento()
        {
            Data = DateTime.Now;
        }
    }
}