using System;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

public class Message : IMessage, IEquatable<IMessage>
{
    internal Message(string title, string content, LvlImportant lvlImportant)
    {
        Title = title;
        Content = content;
        LvlImportant = lvlImportant;
    }

    public LvlImportant LvlImportant { get; }
    public string Title { get; }
    public string Content { get; }

    public bool Equals(IMessage? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return other.GetType() == this.GetType() && Equals((Message)other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(LvlImportant, Title, Content);
    }

    private bool Equals(Message other)
    {
        return LvlImportant.Equals(other.LvlImportant) && Title == other.Title && Content == other.Content;
    }
}