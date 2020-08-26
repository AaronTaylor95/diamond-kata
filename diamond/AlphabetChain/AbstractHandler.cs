using System.Collections.Generic;

namespace diamond.AlphabetChain
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual List<PaddedDiamondRow> Handle(Letter midpoint, DiamondDepth depth)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(midpoint, IncrementDepth(depth));
            }
            else
            {
                return new List<PaddedDiamondRow>();
            }
        }
        private DiamondDepth IncrementDepth(DiamondDepth depth) => new DiamondDepth(depth.ToInt() + 1);
    }    
}