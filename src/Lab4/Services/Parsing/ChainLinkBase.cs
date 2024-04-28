using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Commands.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing;

public abstract class ChainLinkBase : IChainLink
{
    private IChainLink? _next;

    /*[SuppressMessage("", "CA1822", Justification = "d")]
    public static ChainLinkBase Chain(ChainLinkBase firstElement, IList<ChainLinkBase> chain)
    {
        ArgumentNullException.ThrowIfNull(chain);
        ArgumentNullException.ThrowIfNull(firstElement);

        ChainLinkBase current = firstElement;
        foreach (ChainLinkBase elem in chain)
        {
            current._next = elem;
            current = elem;
        }

        return firstElement;
    }*/
    public void AddNext(ChainLinkBase nextChain)
    {
        this._next = nextChain;
    }

    public ICommand? ParseNext(string command)
    {
        if (_next is null)
        {
            return null;
        }

        return _next.Handle(command);
    }

    public abstract ICommand? Handle(string command);
}