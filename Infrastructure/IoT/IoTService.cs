using Domain.Interfaces;

namespace Infrastructure.IoT;

public sealed class IoTService : IIoTService
{
    public bool IsConnected { get; private set; }

    public Task ConnectAsync(
        CancellationToken cancellationToken = default)
    {
        IsConnected = true;

        return Task.CompletedTask;
    }

    public Task DisconnectAsync(
        CancellationToken cancellationToken = default)
    {
        IsConnected = false;

        return Task.CompletedTask;
    }

    public Task PublishAsync(
        string topic,
        string message,
        CancellationToken cancellationToken = default)
    {
        if (!IsConnected)
        {
            throw new InvalidOperationException(
                "The IoT client is not connected.");
        }

        if (string.IsNullOrWhiteSpace(topic))
        {
            throw new ArgumentException(
                "MQTT topic cannot be empty.",
                nameof(topic));
        }

        return Task.CompletedTask;
    }

    public Task SubscribeAsync(
        string topic,
        Func<string, Task> handler,
        CancellationToken cancellationToken = default)
    {
        if (!IsConnected)
        {
            throw new InvalidOperationException(
                "The IoT client is not connected.");
        }

        if (string.IsNullOrWhiteSpace(topic))
        {
            throw new ArgumentException(
                "MQTT topic cannot be empty.",
                nameof(topic));
        }

        ArgumentNullException.ThrowIfNull(handler);

        return Task.CompletedTask;
    }
}
