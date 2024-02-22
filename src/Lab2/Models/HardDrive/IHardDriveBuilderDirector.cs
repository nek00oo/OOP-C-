namespace Itmo.ObjectOrientedProgramming.Lab2.Models.HardDrive;

public interface IHardDriveBuilderDirector
{
    IHardDriveBuilder Direct(IHardDriveBuilder hardDriveBuilder);
}