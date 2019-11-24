using RabbitMQ.Client;

namespace Infrastructure.RabbitMQ
{
    public interface IRabbitMQConnectionFactory
    {
        IConnection CreateConnection();
        void Close();
    }
}
