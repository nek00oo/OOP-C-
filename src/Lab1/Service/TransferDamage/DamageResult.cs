namespace Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

public abstract record DamageResult
{
    private DamageResult() { }
    public sealed record DamageSustained : DamageResult;

    public sealed record DamageOverflow(int Damage) : DamageResult;
}