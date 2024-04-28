using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Commands.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing;

public interface IChainLink
{
    ICommand? ParseNext(string command);
    ICommand? Handle(string command);
}