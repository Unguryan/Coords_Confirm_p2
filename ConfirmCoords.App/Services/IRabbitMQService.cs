using ConfirmCoords.Domain.Events;

namespace ConfirmCoords.App.Services
{
    public interface IRabbitMQService
    {
        Task<bool> SendToQueue<T>(string queueName, T request) where T : class, IBaseEvent;
    }
}
