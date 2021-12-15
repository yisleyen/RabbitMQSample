using RabbitMQ.Client;

namespace RabbitMQSample
{
    public class RabbitMQService
    {
        private string _hostName = "localhost";

        public IConnection GetRabbitMQConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = _hostName
            };

            return connectionFactory.CreateConnection();
        }
    }
}
