using Xunit;
using Infrastructure.RabbitMQ;
using RabbitMQ.Client;

namespace Tests.Integration_Tests
{
    public class RabbitMQTest
    {
        private IConnection _connection;

        [Fact]
        public void TestConnection()
        {
            var connectionDetail = new RabbitMQConnectionDetail() { HostName = "localhost", UserName = "guest", Password = "guest" };

            var rabbitMQConnectionFactory = new RabbitMQConnectionFactory(connectionDetail);
            _connection = rabbitMQConnectionFactory.CreateConnection();

            Assert.True(_connection.IsOpen);
        }
    }
}
