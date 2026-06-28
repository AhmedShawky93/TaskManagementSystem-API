namespace TaskManagementSystem.Application.Exceptions;

public class ValidationException : ApiException
{
    public ValidationException(string message) : base(message)
    {
    }
}