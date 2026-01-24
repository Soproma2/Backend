namespace HomeWork_52___Asp_angular__movies_.Common
{
    public class Result<T>
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public T? Value { get; set; }

        public Result(int status, string? message, T? value) 
        {
            Status = status;
            Message = message;
            Value = value;
        }

        public Result<T> success(string? message, T? value) => new(200, message, value);
        public Result<T> BadRequest(string? message) => new(400, message, default);
        public Result<T> NotFound(string? message) => new(404, message, default);
    }
}
