using Autofac;
using Infrastructure.RabbitMQ;

namespace WongaRabbitMQ
{
    public class Base
    {
        public static IContainer Container { get; set; }

        public static void RegisterTypes()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RabbitMQConnectionFactory>().As<IRabbitMQConnectionFactory>();
            Container = builder.Build();
        }
    }
}