namespace HomeWork_56___Todo___Extension.Common
{
    public class Result<T>
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public T? Value { get; set; }
    }
}
