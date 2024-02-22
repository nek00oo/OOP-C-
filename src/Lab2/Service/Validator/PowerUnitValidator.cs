using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Validator;

public class PowerUnitValidator : IValidationHandler
{
    private IValidationHandler? _nextHandler;
    public IValidationHandler SetNext(IValidationHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public void Validate(IComputer computer, ref IList<IValidateResult> checkList)
    {
        IEnumerable<IConsumeEnergy> consumeEnergies = computer.RamMemories.Concat<IConsumeEnergy>(computer.ExternalMemories)
            .Append(computer.Processor).Append(computer.ProcessorCoolingSystem);
        if (computer.VideoCard != null)
            consumeEnergies = consumeEnergies.Append(computer.VideoCard);
        if (computer.WiFiAdapter != null)
            consumeEnergies = consumeEnergies.Append(computer.WiFiAdapter);

        checkList.Add(computer.PowerUnit.IsPowerUnitCompatibility(consumeEnergies));

        _nextHandler?.Validate(computer, ref checkList);
    }
}