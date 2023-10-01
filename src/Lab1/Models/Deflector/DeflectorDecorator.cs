namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public abstract class DeflectorDecorator : DeflectorBase
{
    protected DeflectorDecorator(DeflectorBase deflector)
    {
        Wrappee = deflector;
    }

    public DeflectorBase Wrappee { get; protected set; }
}