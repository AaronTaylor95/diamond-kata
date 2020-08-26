using System;

namespace diamond
{
    public class Letter
    {
        private char _letter;

        public Letter(char letter)
        {
            _letter = letter;
        }
        public char ToChar() => _letter;
        public override string ToString() => _letter.ToString();
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return false;
            if (obj.GetType() != GetType()) return false;

            return Equals((Letter)obj);
        }
        
        private bool Equals(Letter value)
        {
            return _letter == value._letter;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_letter);
        }
    }
}
