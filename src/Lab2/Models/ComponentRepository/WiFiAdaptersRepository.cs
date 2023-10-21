using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentRepository;

public class WiFiAdaptersRepository
{
    private readonly List<IWiFiAdapter> _wiFiAdapters;

    public WiFiAdaptersRepository()
    {
        _wiFiAdapters = new List<IWiFiAdapter>
        {
            new WiFiAdapter(new WiFiVersion.WiFi4(), new PciEVersion.V2(), new CountType(5)),
            new WiFiAdapter(new WiFiVersion.WiFi5(), new PciEVersion.V4(), new CountType(7)),
        };
    }

    public void AddWiFiAdapters(IComputerComponent component)
    {
        switch (component)
        {
            case IWiFiAdapter wiFiAdapter:
                _wiFiAdapters.Add(wiFiAdapter);
                break;
            default:
                throw new InvalidOperationException("non-existent component type");
        }
    }

    public IEnumerable<IWiFiAdapter> ReturnWiFiAdapters() => _wiFiAdapters;
}