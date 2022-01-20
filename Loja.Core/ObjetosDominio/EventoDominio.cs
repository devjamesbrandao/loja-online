using Loja.Core.Message;
using MediatR;

namespace Loja.Core.ObjetosDominio
{
    public abstract class EventoDominio : Evento
    {
        public DateTime Data { get; private set; }

        protected EventoDominio(Guid idagregado)
        {
            IdAgregado = idagregado;
            Data = DateTime.Now;
        }
    }
}