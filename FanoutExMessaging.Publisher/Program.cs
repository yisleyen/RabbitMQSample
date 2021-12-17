using FanoutExMessaging.Common;
using RabbitMQ.Client;
using System;
using System.Text;

namespace FanoutExMessaging.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbitMQService = new RabbitMQService();

            using (var connnection = rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connnection.CreateModel())
                {
                    channel.ExchangeDeclare("foo.exchange", ExchangeType.Fanout, true, false, null);

                    channel.QueueDeclare("foo.billing", true, false, false, null);

                    channel.QueueDeclare("foo.shipping", true, false, false, null);

                    channel.QueueBind("foo.billing", "foo.exchange", "");

                    channel.QueueBind("foo.shipping", "foo.exchange", "");

                    var publicationAddress = new PublicationAddress(ExchangeType.Fanout, "foo.exchange", "");

                    channel.BasicPublish(publicationAddress, null, Encoding.UTF8.GetBytes("12345 numaralı sipariş geldi"));
                }
            }
        }
    }
}
