using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Confluent.Kafka;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using System.Configuration;
namespace EventStreamingApp
{
    public static class KafkaListenerFunction
    {
        [FunctionName("KafkaTriggerMany")]
        public static void Run(
            [KafkaTrigger("BootstrapServer",
                  "topic",
                  Username = "ConfluentCloudUserName",
                  Password = "ConfluentCloudPassword",
                  Protocol = BrokerProtocol.SaslSsl,
                  AuthenticationMode = BrokerAuthenticationMode.Plain,
                  ConsumerGroup = "$Default")] KafkaEventData<string>[] events, ILogger log)
        {
            foreach (KafkaEventData<string> kevent in events)
            {                
                log.LogInformation($"C# Kafka trigger function processed a message: {kevent.Value}");
            }
        }
    }
}
