using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Validator;

public class VideoCardValidator : IValidationHandler
{
    private IValidationHandler? _nextHandler;

    public IValidationHandler SetNext(IValidationHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public void Validate(IComputer computer, ref IList<IValidateResult> checkList)
    {
        if (computer.Processor is not IProcessorWithVideoCore && computer.VideoCard == null)
            checkList.Add(new NegativeValidateResult.VideoCardIsRequired());
        checkList.Add(new SuccessValidateResult.SuccessCompability());

        _nextHandler?.Validate(computer, ref checkList);
    }
}