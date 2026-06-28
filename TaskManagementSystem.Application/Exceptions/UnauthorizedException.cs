namespace TaskManagementSystem.Application.Exceptions;

public class UnauthorizedException : ApiException
{
    public UnauthorizedException(string message) : base(message)
    {
    }
}