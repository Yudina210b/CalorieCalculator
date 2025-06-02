namespace Common.Infrastructure.Queues.Abstraction
{
    /// <summary>
    /// Интерфейс очереди
    /// </summary>
    /// <typeparam name="T">Тип идентификатора очереди</typeparam>
    public interface IQueue<T>
    {
        /// <summary>
        /// Имя очереди
        /// </summary>
        T QueueName { get; }
    }
}