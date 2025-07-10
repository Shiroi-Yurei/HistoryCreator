namespace Marliazen.Software.Core.Exception
{
    public class MzWrongEnumValueException : System.Exception
    {
        public MzWrongEnumValueException() : base()
        {
        }

        public MzWrongEnumValueException(string message) : base(message)
        {
        }

        public MzWrongEnumValueException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}