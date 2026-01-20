namespace HomeWork_51___Asp_JWT.Common
{
    public class ApiResponse<T>
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public T? Value { get; set; }
    }
}
