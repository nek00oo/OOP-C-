using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public interface IWiFiAdapterWithBluetoothBuilder : IWiFiAdapterBuilder
{
    IWiFiAdapterWithBluetoothBuilder AddBluetoothVersion(BluetoothVersion bluetoothVersion);
}