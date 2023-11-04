using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

public interface IMessage : IEquatable<IMessage>
{
    public int LvlImportant { get; }
    public string Render();
}