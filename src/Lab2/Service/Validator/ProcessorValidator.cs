using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Validator;

public class ProcessorValidator : IValidationHandler
{
    private IValidationHandler? _nextHandler;

    public IValidationHandler SetNext(IValidationHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public void Validate(IComputer computer, ref IList<IValidateResult> checkList)
    {
        checkList.Add(computer.Processor.IsProcessorCompatibility(computer.Motherboard));
        if (computer.Processor is not IProcessorWithVideoCore && computer.VideoCard == null)
            checkList.Add(new NegativeValidateResult.VideoCardIsRequired());

        _nextHandler?.Validate(computer, ref checkList);
    }
}