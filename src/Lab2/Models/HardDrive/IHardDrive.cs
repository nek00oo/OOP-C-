using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.HardDrive;

public interface IHardDrive : IHardDriveBuilderDirector, IExternalMemory, IComputerComponent
{
    public SpeedType SpindleSpeed { get; }
}