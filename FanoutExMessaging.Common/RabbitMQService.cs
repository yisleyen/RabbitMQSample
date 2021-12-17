using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanoutExMessaging.Common
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
