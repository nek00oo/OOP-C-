namespace Itmo.ObjectOrientedProgramming.Lab2.Type;

public abstract record BluetoothVersion
{
    private BluetoothVersion() { }

    private sealed record V1() : BluetoothVersion;

    private sealed record V2() : BluetoothVersion;

    private sealed record V3() : BluetoothVersion;

    private sealed record V4() : BluetoothVersion;

    private sealed record V5() : BluetoothVersion;
}