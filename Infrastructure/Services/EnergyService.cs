using Domain.Interfaces;

namespace Infrastructure.Services;

public sealed class EnergyService : IEnergyService
{
    public Task<EnergyReadingsResponse> GetCurrentReadingsAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        var result = new EnergyReadingsResponse(
            TotalProduction: 5.00m,
            TotalConsumption: 3.50m,
            GridImport: 0.00m,
            GridExport: 1.50m,
            BatteryCharge: 72.00m,
            SolarProduction: 5.00m,
            CurrentPrice: 0.15m,
            Timestamp: DateTime.UtcNow);

        return Task.FromResult(result);
    }

    public Task<OptimizationResult> OptimizeEnergyAsync(
        Guid userId,
        DateTime from,
        DateTime to,
        CancellationToken cancellationToken = default)
    {
        var recommendations = new List<OptimizationRecommendation>
        {
            new(
                Type: "LoadShifting",
                Description:
                    "Schedule flexible appliance usage during peak solar generation.",
                EstimatedSavings: 1.25m,
                ImplementationTime: TimeSpan.FromMinutes(5),
                Priority: 1),

            new(
                Type: "BatteryOptimization",
                Description:
                    "Store excess solar generation before exporting to the grid.",
                EstimatedSavings: 0.85m,
                ImplementationTime: TimeSpan.FromMinutes(2),
                Priority: 2)
        };

        var result = new OptimizationResult(
            Savings: 2.10m,
            CostReduction: 0.32m,
            EfficiencyGain: 12.50m,
            Recommendations: recommendations,
            GeneratedAt: DateTime.UtcNow);

        return Task.FromResult(result);
    }

    public Task<WasteDetectionResult> DetectWasteAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        var devices = new List<WasteDetectionItem>
        {
            new(
                DeviceId: Guid.NewGuid(),
                DeviceName: "Living Room Air Conditioner",
                WastedEnergy: 0.80m,
                EstimatedCost: 0.12m,
                Reason:
                    "The device is consuming power while no occupancy is detected.")
        };

        var result = new WasteDetectionResult(
            TotalWaste: 0.80m,
            EstimatedCost: 0.12m,
            DeviceCount: devices.Count,
            Devices: devices,
            DetectedAt: DateTime.UtcNow);

        return Task.FromResult(result);
    }
}
