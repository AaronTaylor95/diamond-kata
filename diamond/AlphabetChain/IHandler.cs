using System.Collections.Generic;

namespace diamond.AlphabetChain
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        List<PaddedDiamondRow> Handle(Letter midpoint, DiamondDepth depth);
    }
}
