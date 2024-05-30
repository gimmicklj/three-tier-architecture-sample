namespace WebApi.Common.Result;

internal abstract class StatusCode
{
    public static readonly int Success = 200;

    public static readonly int Unauthorized = 401;

    public static readonly int Forbidden = 403;

    public static readonly int Failure = 400;

    public static readonly int ServerError = 500;

}
