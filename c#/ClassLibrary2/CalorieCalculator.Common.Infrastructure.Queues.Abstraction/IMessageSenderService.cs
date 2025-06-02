namespace Common.Infrastructure.Queues.Abstraction
{
    /// <summary>
    /// Сервис для отправки сообщений в очередь
    /// </summary>
    /// <typeparam name="TMessage">Тип отправляемого сообщения</typeparam>
    public interface IMessageSenderService<TMessage>
    {
        /// <summary>
        /// Отправить сообщение в очередь
        /// </summary>
        /// <param name="message">Отправляемое сообщение</param>
        void Send(TMessage message);
    }
}