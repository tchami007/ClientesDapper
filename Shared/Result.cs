namespace ClientesDapper.Shared
{
    public class Result<T>
    {
        private T Value { get; set; }
        private bool IsSuccess { get; set; }
        private string? ErrorMessage { get; set; }

        private Result(T value)
        {
            IsSuccess = true;
            ErrorMessage = string.Empty;
        }
        private Result( string error)
        { 
            IsSuccess = false;
            ErrorMessage = error;
        }

        public static Result<T> Success(T value) => new Result<T>(value);

        public static Result<T> Failure(string errorMessage) => new Result<T>(errorMessage);

    }
}
