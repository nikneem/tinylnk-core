using TinyLink.Core.ErrorCodes;

namespace TinyLink.Core.Exceptions;

public class UrlShortnerPaginationException : UrlShortnerBaseException
{
    public UrlShortnerPaginationException(UrlShortnerPaginationErrorCode errorCode) : base(errorCode)
    {
    }
}
