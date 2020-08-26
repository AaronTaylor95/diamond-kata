using System.Collections.Generic;

namespace diamond.AlphabetChain
{
    public class InsertRowItemHandler : AbstractHandler
    {
        private const int zeroBasedIndexOffset = 1;
        private PaddedDiamondRow _row;

        public virtual List<PaddedDiamondRow> Process(Letter midpoint, DiamondDepth depth, Letter chainLetter)
        {
            var rowLength = RowLength(midpoint);
            _row = new PaddedDiamondRow(depth, chainLetter, rowLength);

            var result = new List<PaddedDiamondRow> { _row };

            if (!midpoint.Equals(chainLetter))
            {
                result.AddRange(MoveDownChain(midpoint, depth));
            }

            return result;
        }

        private int RowLength(Letter midpoint) => 
            PalindromeRowLength(Consts.Alphabet.IndexOf(midpoint.ToChar()) + zeroBasedIndexOffset);
        private int PalindromeRowLength(int index) => index * 2 - zeroBasedIndexOffset;
        private List<PaddedDiamondRow> MoveDownChain(Letter midpoint, DiamondDepth depth)
        {
            var result = base.Handle(midpoint, depth);
            result.Add(_row);

            return result;
        }
    }
}
