namespace Hedgehog
{
    public class HedgehogException : Exception
    {
        public HedgehogException() { }
        public HedgehogException(string message) : base(message) { }
        public HedgehogException(string message, Exception inner) : base(message, inner) { }
    }
}
