using RabbitMQ.Client;

namespace Infrastructure.RabbitMQ
{
    public class RabbitMQConnectionFactory : IRabbitMQConnectionFactory
    {
        private readonly RabbitMQConnectionDetail _connectionDetail;
        private IConnection _connection;

        public RabbitMQConnectionFactory(RabbitMQConnectionDetail connectionDetail)
        {
            _connectionDetail = connectionDetail;
        }

        public IConnection CreateConnection()
        {
            var factory = new ConnectionFactory {
                HostName = _connectionDetail.HostName,
                UserName = _connectionDetail.UserName,
                Password = _connectionDetail.Password };
                _connection = factory.CreateConnection();
            return _connection;
        }

        public void Close()
        {
            _connection.Close();
        }
    }
}
