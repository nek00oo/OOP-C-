using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Validator;

public interface IValidationHandler
{
    IValidationHandler SetNext(IValidationHandler handler);
    void Validate(IComputer computer, ref IList<IValidateResult> checkList);
}