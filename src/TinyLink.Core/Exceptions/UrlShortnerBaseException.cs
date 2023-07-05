using TinyLink.Core.ErrorCodes;

namespace TinyLink.Core.Exceptions;

public class UrlShortnerBaseException : Exception
{
    public UrlShortnerBaseException(UrlShortnerErrorCode errorCode, Exception? innerException = null) : base(errorCode.Code, innerException)
    {

    }
}