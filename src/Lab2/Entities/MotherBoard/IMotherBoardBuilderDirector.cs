namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public interface IMotherBoardBuilderDirector
{
    IMotherBoardBuilder Direct(IMotherBoardBuilder motherBoardBuilder);
}