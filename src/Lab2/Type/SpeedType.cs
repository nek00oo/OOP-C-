using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Type;

public class SpeedType
{
    public SpeedType(int speed)
    {
        if (speed < 0)
            throw new InvalidOperationException($"The speed argument cannot be negative: {speed}");
        Speed = speed;
    }

    public int Speed { get; }
}