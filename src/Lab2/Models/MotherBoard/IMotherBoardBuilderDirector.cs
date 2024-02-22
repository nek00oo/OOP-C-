namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;

public interface IMotherBoardBuilderDirector
{
    IMotherBoardBuilder Direct(IMotherBoardBuilder motherBoardBuilder);
}