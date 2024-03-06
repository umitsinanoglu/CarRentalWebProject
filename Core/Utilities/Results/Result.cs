namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success)
        {
            IsSuccess = success;
        }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public bool IsSuccess { get; }

        public string Message { get; }
    }
}
