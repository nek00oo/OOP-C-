using System;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

public interface IMessage : IEquatable<IMessage>
{
    public LvlImportant LvlImportant { get; }
    public string Title { get; }
    public string Content { get; }
    public string Render();
}