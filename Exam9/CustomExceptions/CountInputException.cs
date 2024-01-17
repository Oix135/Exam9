namespace Exam9.CustomExceptions
{
    internal class CountInputException:Exception
    {
        public CountInputException(string message) : base(message) { }
    }
}
