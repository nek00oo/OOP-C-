using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IProcessorWithVideoCoreBuilder : IProcessorBuilder
{
    IProcessorWithVideoCoreBuilder AddVideoCore(VideoCoreType videoCore);
}