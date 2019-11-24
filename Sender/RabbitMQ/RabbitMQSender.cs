using System;
using RabbitMQ.Client;
using Infrastructure.RabbitMQ;

namespace WongaRabbitMQ.RabbitMQ
{
    public class RabbitMQSender
    {
        private static IModel _model;

        public RabbitMQSender(IModel model)
        {
            _model = model;
        }

        public void SendMessage(object message)
        {            
            _model.BasicPublish("", Constants.QUEUENAME, null, message.Serialize());
            Console.WriteLine($" Message sent");
        }
    }
}
