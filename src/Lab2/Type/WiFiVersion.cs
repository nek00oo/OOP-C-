namespace Itmo.ObjectOrientedProgramming.Lab2.Type;

public abstract record WiFiVersion
{
    private WiFiVersion() { }

    public sealed record WiFi6() : WiFiVersion;

    public sealed record WiFi5() : WiFiVersion;

    public sealed record WiFi4() : WiFiVersion;
}
