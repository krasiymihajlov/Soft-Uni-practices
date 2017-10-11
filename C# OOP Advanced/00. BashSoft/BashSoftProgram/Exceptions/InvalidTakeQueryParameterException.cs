namespace BashSoftProgram.Exceptions
{
    using System;

    public class InvalidTakeQueryParameterException : Exception
    {
        private const string InvalidTakeQuantityParameter = "The take command expected does not match the format wanted!";

        public InvalidTakeQueryParameterException() : base(InvalidTakeQuantityParameter)
        {
        }

        public InvalidTakeQueryParameterException(string message)
            : base(message)
        {
        }
    }
}
