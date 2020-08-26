using diamond.AlphabetChain;
using System.Collections.Generic;
using System.Linq;

namespace diamond
{
    public class PaddedDiamond
    {
        private char _letter;        
        private List<string> _rows;
        private List<PaddedDiamondRow> _diamondRows;

        public PaddedDiamond(char letter)
        {
            _letter = letter;
            _diamondRows = new List<PaddedDiamondRow>();
        }
        public List<string> Print()
        {
            // all of this will be replaced with chain
            var lettersToDisplay = GetLettersToDisplay();
            var rowLength = lettersToDisplay.Length * 2 - 1;

            _rows = lettersToDisplay.Select((x, i) => new PaddedDiamondRow(new DiamondDepth(i),
                                                                           new Letter(x),
                                                                           rowLength).ToString())
                                            .ToList();

            var rowsAfterMidpoint = new List<string>();
            rowsAfterMidpoint.AddRange(_rows);
            rowsAfterMidpoint.Remove(rowsAfterMidpoint.Last());
            rowsAfterMidpoint.Reverse();

            _rows.AddRange(rowsAfterMidpoint);

            return _rows;
        }

        public List<PaddedDiamondRow> Printxx()
        {
            return _diamondRows;
        }
        private string GetLettersToDisplay() => Consts.Alphabet.Substring(0, GetMidpoint());
        private int GetMidpoint() => Consts.Alphabet.IndexOf(_letter) + 1;
    }
}
