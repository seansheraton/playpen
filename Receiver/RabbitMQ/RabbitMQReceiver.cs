using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Infrastructure.RabbitMQ;

namespace WongaRabbitMQ.RabbitMQ
{    
    public class RabbitMQReceiver
    {
        private readonly IRabbitMQConnectionFactory _connectionFactory;

        public RabbitMQReceiver(IRabbitMQConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void ProcessMessages()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(Constants.QUEUENAME, true, false, false, null);

                    channel.BasicQos(0, 1, false);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (ch, ea) =>
                    {
                        var body = ea.Body;
                        var message = (String)ea.Body.DeSerialize(typeof(String));
                        Console.WriteLine($"Hello {message}, I am your father!");
                        channel.BasicAck(ea.DeliveryTag, false);
                    };

                    channel.BasicConsume(Constants.QUEUENAME, false, consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }    
    }
}
