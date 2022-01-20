namespace Loja.Core.Message
{
    public abstract class Mensagem
    {
        public string TipoMensagem { get; protected set; }
        public Guid IdAgregado { get; protected set; }

        protected Mensagem()
        {
            TipoMensagem = GetType().Name;
        }
    }
}