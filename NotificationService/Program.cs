using MassTransit;
using MessageContracts;
using MessageContracts.Consumers;

var bus = BusConfigurator.ConfigureBus(configuration =>
    {
        configuration.ReceiveEndpoint(RabbitMQConstants.NotificationServiceQueueName, e =>
        {
            e.Consumer<SubmittedOrderNotificationEventConsumer>();
        });
    });