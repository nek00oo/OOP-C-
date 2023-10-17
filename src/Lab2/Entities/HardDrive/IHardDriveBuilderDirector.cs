namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HardDrive;

public interface IHardDriveBuilderDirector
{
    IHardDriveBuilder Direct(IHardDriveBuilder hardDriveBuilder);
}