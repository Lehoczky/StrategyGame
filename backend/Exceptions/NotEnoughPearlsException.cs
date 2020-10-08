namespace backend.Exceptions
{
    using System;

    public class NotEnoughPearlsException : Exception
    {
        public NotEnoughPearlsException()
            : base("Not enough pearls")
        {
        }

        public NotEnoughPearlsException(string message)
            : base(message)
        {
        }

        public NotEnoughPearlsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}