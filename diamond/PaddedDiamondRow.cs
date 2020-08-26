namespace diamond
{
    public class PaddedDiamondRow
    {
        private string _value = "";
        public PaddedDiamondRow(DiamondDepth depth, Letter letter, int rowLength)
        {
            PadMiddle(depth.ToInt(), letter.ToChar());
            PadSides(rowLength);
        }
        public override string ToString() => _value;

        private void PadSides(int rowLength)
        {
            var totalPadding = PaddingToApply(rowLength);
            if (totalPadding > 0)
            {
                var paddingPerSide = totalPadding / 2;
                _value = $"{PadLeft(paddingPerSide)}{_value}{PadRight(paddingPerSide)}";
            }
        }
        
        private void PadMiddle(int row, char letter)
        {
            _value = $"{letter}{PadRight(WhitespaceToAddToRowMiddle(row))}";

            if (row != 0)
                MakeValuePalindrome(letter);
        }
        private void MakeValuePalindrome(char letter) => _value += letter;
        private int WhitespaceToAddToRowMiddle(int row) => row == 0 ? 0 : (row * 2) - 1;
        private int PaddingToApply(int rowLength) => rowLength - _value.Length;
        private string PadRight(int padding) => "".PadRight(padding);
        private string PadLeft(int padding) => "".PadLeft(padding);
    }
}
