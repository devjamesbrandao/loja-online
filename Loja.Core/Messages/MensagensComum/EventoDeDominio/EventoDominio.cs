using MediatR;

namespace Loja.Core.Message.MensagensComum.EventoDeDominio
{
    public abstract class EventoDominio : Evento
    {
        public DateTime Timestamp { get; private set; }

        protected EventoDominio(Guid aggregateId)
        {
            IdAgregado = aggregateId;

            Timestamp = DateTime.Now;
        }
    }
}