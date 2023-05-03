namespace MirrorTube.Common.Models
{
    public sealed class HexId
    {
        readonly string _value;
        public HexId(string value)
        {
            ValidateHexId(value);
            this._value = value;
        }
        public static implicit operator string(HexId d)
        {
            return d._value;
        }
        public static implicit operator HexId(string d)
        {
            return new HexId(d);
        }

        private static void ValidateHexId(string inputValue)
        {
            const int _TOTAL_LENGTH = 64;
            if (inputValue.Length != _TOTAL_LENGTH) { throw new InvalidIdException("Length must be exactly 64 characters long"); }
            if (inputValue.All("0123456789abcdefABCDEF".Contains) == false) { throw new InvalidIdException("Must only contain characters 0-9 and A-F"); }
        }
    }

    public class InvalidIdException : Exception
    {
        public InvalidIdException()
        {
        }

        public InvalidIdException(string message)
            : base(message)
        {
        }

        public InvalidIdException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
