using Confluent.Kafka;

namespace KafkaQuickStart;

public class Consumer
{
    public static async Task ExecuteAsync()
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:29092",
            GroupId = "test-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<Null, string>(config).Build();
        consumer.Subscribe("test-topic");

        while (true)
        {
            var cr = consumer.Consume();
            Console.WriteLine($"Consumed message '{cr.Message.Value}' at: '{cr.TopicPartitionOffset}'.");
        }
    }
}