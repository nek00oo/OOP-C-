namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public interface IMotherboard : IMotherBoardBuilderDirector, IComputerComponent
{
    public bool IsProcessorCompatibility(IProcessor processor);
}