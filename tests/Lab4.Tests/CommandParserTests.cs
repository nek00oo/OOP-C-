using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FileParse;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.TreeParse;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CommandParserTests
{
    public static IEnumerable<object[]> GetCommand()
    {
        yield return new object[]
        {
            new string("connect C:\\Users\\valer\\RiderProjects\\nek00oo\\src\\Lab4\\ -m local"),
            new ConnectCommand("connect C:\\Users\\valer\\RiderProjects\\nek00oo\\src\\Lab4\\", new FileSystemMode.Local()),
        };
        yield return new object[]
        {
            new string("tree list -d 2 -m console"),
            new TreeListCommand(new ConsoleOutputMode(), 2),
        };
        yield return new object[]
        {
            new string("tree goto Parser\\"),
            new TreeGoTo("tree goto Parser\\"),
        };
        yield return new object[]
        {
            new string("file move MyFile.txt Iterator"),
            new MoveFileCommand("MyFile.txt", "Iterator"),
        };
        yield return new object[]
        {
            new string("file rename Iterator\\MyFile.txt RenameFile.txt"),
            new RenameFileCommand("Iterator\\MyFile.txt", "RenameFile.txt"),
        };
        yield return new object[]
        {
            new string("file delete C:\\Users\\valer\\RiderProjects\\nek00oo\\src\\Lab4\\Iterator\\Rename2.txt"),
            new FileDeleteCommand("C:\\Users\\valer\\RiderProjects\\nek00oo\\src\\Lab4\\Iterator\\Rename2.txt"),
        };
        yield return new object[]
        {
            new string("file copy C:\\Users\\valer\\RiderProjects\\nek00oo\\src\\Lab4\\File.txt OutputMode"),
            new CopyFileCommand("C:\\Users\\valer\\RiderProjects\\nek00oo\\src\\Lab4\\File.txt", "OutputMode"),
        };
        yield return new object[]
        {
            new string("disconnect"),
            new DisconnectCommand(),
        };
    }

    [Theory]
    [MemberData(nameof(GetCommand))]
    public void TestedParser_ExpectedCreateCommand(string command, ICommand expectedCommand)
    {
        // Arrange
        ICommandParser commandParser = new ConnectParse();
        commandParser.SetChainFlagParse(new FileSystemModeParse())
            .SetNextCommandParse(new TreeParse())
            .SetNextCommandParse(new ListParse())
            .SetChainFlagParse(new DepthParse(), new OutputModeParse())
            .SetNextCommandParse(new GoToParse())
            .SetChainFlagParse(new DepthParse())
            .SetNextCommandParse(new FileParse())
            .SetNextCommandParse(new MoveParse())
            .SetNextCommandParse(new ShowParse())
            .SetChainFlagParse(new OutputModeParse())
            .SetNextCommandParse(new CopyParse())
            .SetNextCommandParse(new DeleteParse())
            .SetNextCommandParse(new RenameParse())
            .SetNextCommandParse(new DisconnectParse());

        // Act
        IIterator iterator = new CommandIterator(command);
        ParseResult parseResult = commandParser.CheckCommand(iterator);

        // Assert
        if (parseResult is ParseResult.Success success)
        {
            Assert.Equivalent(expectedCommand, success.Command);
        }
        else
        {
            Assert.Fail();
        }
    }
}