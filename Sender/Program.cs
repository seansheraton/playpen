using System;
using WongaRabbitMQ.RabbitMQ;
using Autofac;
using Infrastructure.RabbitMQ;

namespace WongaRabbitMQ
{
    public class Program : Base
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name");

            string name = Console.ReadLine();

            RegisterTypes();

            var connectionDetail = new RabbitMQConnectionDetail() { HostName = "localhost", UserName = "guest", Password = "guest" };

            using (var scope = Container.BeginLifetimeScope())
            {
                var connection = scope.Resolve<IRabbitMQConnectionFactory>(new TypedParameter(typeof(RabbitMQConnectionDetail), connectionDetail));
                var client = new RabbitMQSender(connection.CreateConnection().CreateModel());
                client.SendMessage(name);
            }

            string message = $"Hello my name is, {name}";
        }
    }
}
