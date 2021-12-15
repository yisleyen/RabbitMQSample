using System;

namespace RabbitMQSample
{
    class Program
    {
        private static string _queueName = "YISLEYEN";
        private static Publisher _publisher;
        private static Consumer _consumer;

        static void Main(string[] args)
        {
            _publisher = new Publisher(_queueName, "Hello RabittiMQ World!");

            _consumer = new Consumer(_queueName);
        }
    }
}
