namespace api_cadastro_backend.Exceptions;

public class NotFoundEmailUser : Exception
{
    public NotFoundEmailUser(string message) :base(message)
    {
        
    }
}