namespace Homework_67_Asp___CompanyEvents.Common
{
    public class Result
    {
        public bool IsSuccess { get; protected set; }
        public string? Error { get; protected set; }

        protected Result(bool isSuccess, string? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, null);
        public static Result Failure(string error) => new(false, error);

        public static Result<T> Success<T>(T data) => new(data, true, null);
        public static Result<T> Failure<T>(string error) => new(default!, false, error);
    }

    public class Result<T> : Result
    {
        public T Data { get; private set; }

        internal Result(T data, bool isSuccess, string? error)
            : base(isSuccess, error)
        {
            Data = data;
        }
    }
}
