using System;
using Itmo.ObjectOrientedProgramming.Lab4.ExecuteParse;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FileParse;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.TreeParse;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
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
        var commandExecute = new CommandExecute(commandParser);
        while (true)
        {
            string? command = Console.ReadLine();
            if (command is not null)
            {
                ExecuteResult result = commandExecute.ExecuteParse(command);
                if (result is ExecuteResult.Success success)
                    Console.WriteLine(success.Complete);
                else if (result is ExecuteResult.ExecutionError error)
                    Console.WriteLine(error.Error);
            }
        }
    }
}

// connect C:\Users\valer\RiderProjects\nek00oo\src\Lab4\ -m local
// tree list -d 2 -m console
// tree goto Parser\
// tree goto src\Lab4\Parser\
// tree list -m console -d 2
// file move MyFile.txt Iterator
// file rename Iterator\MyFile.txt RenameFile.txt
// file rename Iterator\RenameFile.txt Rename2.txt
// file delete C:\Users\valer\RiderProjects\nek00oo\src\Lab4\Iterator\Rename2.txt
// file copy C:\Users\valer\RiderProjects\nek00oo\src\Lab4\File.txt OutputMode
// disconnect
