namespace DOMAIN.Exceptions.Types
{
    public class UserNotFoundException() : GeneralException("Usuario NO Encontrado") { }

    public class UserLoginNotFoundException() : GeneralException("Credenciales incorrectas") { }

    public class UserNotActiveException() : GeneralException("Usuario Inactivo") { }

    public class UserNotAuthException() : ForbiddenException("Usuario Debe Realizar Login") { }
}
