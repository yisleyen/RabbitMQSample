using FanoutExMessaging.Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace FanoutExMessaging.ShippingConsumer
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
                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.Span;
                        var message = Encoding.UTF8.GetString(body);

                        Console.WriteLine("foo.shipping üzerinden mesaj alındı: {0}", message);
                    };

                    channel.BasicConsume("foo.shipping", false, consumer);
                    Console.ReadLine();
                }
            }
        }
    }
}
