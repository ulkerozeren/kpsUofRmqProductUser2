using kpsUowRmqTest.RabbitMq;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace kpsUowRmqTest.RabbitMQ
{
    public class PublisherHelper
    {
        public PublisherHelper(string queueName, string message)
        {
            ConnectionHelper connectionHelper = new ConnectionHelper();
            using (IConnection connection = connectionHelper.Connection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);
                    channel.BasicPublish("", queueName, false, null, Encoding.UTF8.GetBytes(message));
                    //Console.WriteLine("SEND: " + queueName + ", Message: " + message + " , Second: " + DateTime.Now.Second);
                }
            }
        }
    }
}
