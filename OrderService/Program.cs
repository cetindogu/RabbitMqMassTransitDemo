using MassTransit;
using MessageContracts;
using MessageContracts.Consumers;

var bus = BusConfigurator.ConfigureBus(configuration =>
{
    configuration.ReceiveEndpoint(RabbitMQConstants.OrderServiceQueueName, e =>
    {
        // Variations
        // e.Consumer(() => new SubmitOrderCommandConsumer());
        // e.Consumer(typeof(SubmitOrderCommandConsumer), type => Activator.CreateInstance(type));
        e.Consumer<SubmitOrderCommandConsumer>();
        e.UseMessageRetry(r => r.Immediate(5));
    });
});

await bus.StartAsync();

Console.WriteLine("Listening order commands... Press any key to exit.");
Console.ReadKey();

await bus.StopAsync();