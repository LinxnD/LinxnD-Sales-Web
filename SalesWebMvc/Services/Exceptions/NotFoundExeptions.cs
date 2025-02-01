namespace SalesWebMvc.Services.Exceptions
{
    public class NotFoundExeptions : ApplicationException
    {
        public NotFoundExeptions(string message) : base(message) 
        {
        }
    }
}
