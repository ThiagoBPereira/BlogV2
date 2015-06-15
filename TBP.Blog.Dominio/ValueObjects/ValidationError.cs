namespace TBP.Blog.Dominio.ValueObjects
{
    public class ValidationError
    {
        public string Message { get; set; }
        public ValidationError(string message)
        {
            Message = message;
        }
    }
}
