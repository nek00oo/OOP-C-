using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComputerBuilder;

public interface IVideoCardBuilderComputerComputer : IVideoCardOrExternalMemoryBuilderComputer
{
    IExternalMemoryBuilderComputerComputer AddVideoCard(IVideoCard videoCard);
}