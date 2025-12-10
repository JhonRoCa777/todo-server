namespace DOMAIN.Exceptions.Types
{
    public class TodoNotFoundException() : UnauthorizedException("TODO NO Registrado") { }

    public class TodoNotActiveException() : GeneralException("TODO Inactivo") { }
}
