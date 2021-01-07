namespace CrudBackend.Domain.Core.Shared.Notificacao
{
    public class NotificacaoDominio : Evento.Evento
    {
        public NotificacaoDominio(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; private set; }
        public string Value { get; private set; }
    }
}
