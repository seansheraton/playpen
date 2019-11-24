using WongaRabbitMQ.RabbitMQ;
using Infrastructure.RabbitMQ;
using Autofac;

namespace WongaRabbitMQ
{
    public class Program : Base
    {
        static void Main(string[] args)
        {
            RegisterTypes();

            var connectionDetail = new RabbitMQConnectionDetail() { HostName = "localhost", UserName = "guest", Password = "guest" };

            using (var scope = Container.BeginLifetimeScope())
            {
                var connection = scope.Resolve<IRabbitMQConnectionFactory>(new TypedParameter(typeof(RabbitMQConnectionDetail), connectionDetail));
                RabbitMQReceiver client = new RabbitMQReceiver(connection);
                client.ProcessMessages();
            }
        }
    }
}
