namespace HomeWork_55___Student_System___Asp___angular.Common
{
    public class Result<T>
    {
        public int Status { get; set; }
        public string? message { get; set; }
        public T? Value { get; set; }
    }
}
