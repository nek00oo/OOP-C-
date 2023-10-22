using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.WiFiAdapter;

public interface IBluetoothCapable
{
    public BluetoothVersion BluetoothVersion { get; }
}