using Confluent.Kafka;
using System;
using System.Net;
using System.Threading.Tasks;

namespace kafka
{
    public class Program
    {
        static void  Main(string[] args)
        {
            
            process();
        }
        
        public async static void process()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "10.1.10.36:9092",
                ClientId = Dns.GetHostName(),
            };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                string text = null;

                while (text!="quit")
                {
                    Console.Write("Add Message");
                    text=Console.ReadLine();
                    producer.ProduceAsync("message",new Message<Null, string> { Value = text });
                    //Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");


                }   
                producer.Flush(new TimeSpan(100));
            }
        }
            
        }

    }
