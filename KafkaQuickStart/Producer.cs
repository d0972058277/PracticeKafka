using Confluent.Kafka;

namespace KafkaQuickStart;

public class Producer
{
    public static async Task ExecuteAsync()
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:29092"
        };

        using var producer = new ProducerBuilder<Null, string>(config).Build();

        for (var i = 0; i < 1; i++)
        {
            var message = $"Hello Kafka {i}";
            var result = await producer.ProduceAsync("test-topic", new Message<Null, string> { Value = message });
            Console.WriteLine($"Delivered '{result.Value}' to '{result.TopicPartitionOffset}'");
        }

        Console.WriteLine("Done producing.");
    }
}