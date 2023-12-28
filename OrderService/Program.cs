using MassTransit;
using MessageContracts;
using OrderService;

var bus = BusConfigurator.ConfigureBus(configuration =>
{
    configuration.ReceiveEndpoint(RabbitMQConstants.OrderServiceQueueName, e =>
    {
        // Variations
        // e.Consumer(() => new SubmitOrderCommandConsumer());
        // e.Consumer(typeof(SubmitOrderCommandConsumer), type => Activator.CreateInstance(type));
        e.Consumer<SubmitOrderCommandConsumer>();
    });
});

await bus.StartAsync();

Console.WriteLine("Listening order commands... Press any key to exit.");
Console.ReadKey();

await bus.StopAsync();