namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorDecorator : DeflectorBase
{
    public DeflectorDecorator(DeflectorBase deflector)
    {
        Wrappee = deflector;
    }

    public DeflectorBase Wrappee { get; protected set; }
}