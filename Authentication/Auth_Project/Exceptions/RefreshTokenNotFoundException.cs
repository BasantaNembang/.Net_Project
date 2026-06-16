namespace Auth_Project.Exceptions
{
    public class RefreshTokenNotFoundException(string message) 
        : Exception(message)
    {
    }
}
