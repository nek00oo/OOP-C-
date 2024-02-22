using System;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

public class Message : IMessage, IEquatable<IMessage>
{
    internal Message(string title, string content, int lvlImportant)
    {
        Title = title;
        Content = content;
        if (lvlImportant < 0)
            throw new InvalidOperationException("The importance level should not be negative");
        LvlImportant = lvlImportant;
    }

    public int LvlImportant { get; }
    public string Title { get; }
    public string Content { get; }
    public string Render()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(Title)
            .Append('\n')
            .Append(Content);
        return stringBuilder.ToString();
    }

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