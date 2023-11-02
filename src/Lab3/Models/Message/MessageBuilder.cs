using System;
using System.Collections.Generic;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

public class MessageBuilder : IMessageBuilder
{
    private string? _title;
    private List<string> _contents;
    private LvlImportant? _lvlImportant;

    public MessageBuilder()
    {
        _contents = new List<string>();
    }

    public IMessageBuilder SelectTitle(string title)
    {
        _title = title;
        return this;
    }

    public IMessageBuilder SelectContent(string content)
    {
        _contents.Add(content);
        return this;
    }

    public IMessageBuilder SetLvlImportantForMessage(LvlImportant lvlImportant)
    {
        _lvlImportant = lvlImportant;
        return this;
    }

    public IMessage Build()
    {
        var builder = new StringBuilder();
        foreach (string content in _contents)
            builder.Append('\n').Append(content);
        return new Message(
            _title ?? throw new ArgumentNullException(nameof(_title)),
            builder.ToString() ?? throw new ArgumentNullException(nameof(_contents)),
            _lvlImportant ?? throw new ArgumentNullException(nameof(_title)));
    }
}