using MediatR;

namespace Loja.Core.Message.Notificacoes
{
    public class NotificacaoDominio : Mensagem, INotification
    {
        public DateTime Timestamp { get; private set; }
        public Guid IdNotificacaoDominio { get; private set; }
        public string Chave { get; private set; }
        public string Valor { get; private set; }
        public int Versao { get; private set; }

        public NotificacaoDominio(string key, string value)
        {
            Timestamp = DateTime.Now;
            IdNotificacaoDominio = Guid.NewGuid();
            Versao = 1;
            Chave = key;
            Valor = value;
        }
    }
}