using Microsoft.AspNetCore.SignalR;

namespace API.Hubs;

public class EnergyHub : Hub
{
    public async Task SubscribeToDevice(string deviceId)
    {
        await Groups.AddToGroupAsync(
            Context.ConnectionId,
            $"device-{deviceId}");
    }

    public async Task UnsubscribeFromDevice(string deviceId)
    {
        await Groups.RemoveFromGroupAsync(
            Context.ConnectionId,
            $"device-{deviceId}");
    }

    public async Task SendDeviceReading(
        string deviceId,
        object reading)
    {
        await Clients
            .Group($"device-{deviceId}")
            .SendAsync(
                "DeviceReading",
                deviceId,
                reading);
    }
}
