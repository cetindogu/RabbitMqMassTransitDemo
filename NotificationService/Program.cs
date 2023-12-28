using MassTransit;
using MessageContracts;
using NotificationService;

var bus = BusConfigurator.ConfigureBus(configuration =>
    {
        configuration.ReceiveEndpoint(RabbitMQConstants.NotificationServiceQueueName, e =>
        {
            e.Consumer<SubmittedOrderNotificationEventConsumer>();
        });
    });