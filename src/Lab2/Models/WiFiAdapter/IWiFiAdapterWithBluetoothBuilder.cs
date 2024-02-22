using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.WiFiAdapter;

public interface IWiFiAdapterWithBluetoothBuilder : IWiFiAdapterBuilder
{
    IWiFiAdapterWithBluetoothBuilder AddBluetoothVersion(BluetoothVersion bluetoothVersion);
}