using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Iterator;

public class CommandIterator : IIterator
{
    private readonly IReadOnlyCollection<string> _command;
    private int _currentPosition;

    public CommandIterator(string command)
    {
        _command = command.Split(' ');
    }

    public bool MoveNext()
    {
        if (_command.ElementAt(_currentPosition).StartsWith("-", StringComparison.InvariantCulture))
            return false;
        _currentPosition++;
        return _currentPosition < _command.Count;
    }

    public string GetCurrent() => _command.ElementAt(_currentPosition);
}