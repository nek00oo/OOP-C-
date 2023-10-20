using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Computer;
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
        throw new NotImplementedException();
    }
}