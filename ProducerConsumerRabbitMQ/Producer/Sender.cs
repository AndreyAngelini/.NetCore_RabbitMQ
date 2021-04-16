using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false , null);
                string message = string.Format("Getting started with .Net Core and RabbitMQ. {0}",DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("","BasicTest",null, body);

                Console.WriteLine("Sent message {0}...", message);
            }
            Console.WriteLine("Press any key to exit the Sender App.... ");
            Console.ReadLine();
        }
    }
}
