using System.Net;

namespace DOMAIN.Exceptions
{
    public class CustomException(string _Message, HttpStatusCode _ErrorCode)
            : Exception(_Message)
    {
        public HttpStatusCode ErrorCode { get; } = _ErrorCode;
    }

    /* SE MUESTRAN AL USUARIO, SIN ACCIÓN POSTERIOR */
    public class GeneralException(string _Message)
        : CustomException(_Message, HttpStatusCode.BadRequest)
    { }

    /* SE MUESTRAN AL USUARIO Y REDIRIGEN AL HOME */
    public class UnauthorizedException(string _Message)
        : CustomException(_Message, HttpStatusCode.Unauthorized)
    { }

    /* SE MUESTRAN AL USUARIO Y REDIRIGEN AL LOGIN */
    public class ForbiddenException(string _Message)
        : CustomException(_Message, HttpStatusCode.Forbidden)
    { }
}
