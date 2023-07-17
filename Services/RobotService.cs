using Grpc.Core;
using GrpcRobot;
using static GrpcGreeter.Services.RobotService;

namespace GrpcGreeter.Services;

#region snippet
public class RobotService : Robot.RobotBase
{
    private readonly ILogger<RobotService> _logger;
    readonly RobotDataReply[] deviceArray = {
        new RobotDataReply{DeviceId = "1", DeviceName = "OTTO", DeviceFleet = "San Francisco" },
        new RobotDataReply{DeviceId = "2", DeviceName = "MiR", DeviceFleet = "San Mateo" },
        new RobotDataReply{DeviceId = "3", DeviceName = "AQI Sensor", DeviceFleet = "Texas" }
    };
    public RobotService(ILogger<RobotService> logger)
    {
        _logger = logger;
    }

    public override Task<RobotDataReply> ReturnSingleDeviceData(RobotDataRequest request, ServerCallContext context)
    {
        RobotDataReply? d = Array.Find(deviceArray, _ => _.DeviceId == request.DeviceId);
        Console.WriteLine($"{request.DeviceId} {d}");
        return Task.FromResult(new RobotDataReply
        {
            DeviceId = d.DeviceId,
            DeviceName = d.DeviceName,
            DeviceFleet = d.DeviceFleet,
        });
    }


}
#endregion