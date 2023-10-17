using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentRepository;

public interface IComponentRepository
{
    public void AddComponent(IComputerComponent component);
    public IEnumerable<IComputerComponent> AllComponents();

    public IEnumerable<IComputerComponent> FilterComponentsByType<T>()
        where T : IComputerComponent;
}