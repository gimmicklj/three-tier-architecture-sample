using WebApi.Common.Helper;
namespace WebApi.Common.Result;

public class ApiResult<T>
{
    public bool IsSuccess { get; private set; }
    public int Code { get; private set; }
    public string? Message { get; private set; }
    public T? Data { get; private set; }
    public Guid RequestId { get; private set; }
    public long Timestamp { get; private set; }

    private ApiResult(bool isSuccess, int code, string? message, T? data = default, 
        Guid requestId = default, long timestamp = default)
    {
        IsSuccess = isSuccess;
        Code = code;
        Message = message;
        Data = data;
        RequestId = requestId;
        Timestamp = timestamp;
    }

    public static ApiResult<T> Ok()
        => new(true, StatusCode.Success, "Success", requestId: Guid.NewGuid(), 
            timestamp: DateTimeHelper.DateTimeToStamp(DateTime.UtcNow));

    public static ApiResult<T> Ok(string message) 
        => new(true, StatusCode.Success, message, requestId: Guid.NewGuid(), 
            timestamp: DateTimeHelper.DateTimeToStamp(DateTime.UtcNow));

    public static ApiResult<T> Ok(T data) 
        => new(true, StatusCode.Success, "Success", data, requestId: Guid.NewGuid(), 
            timestamp: DateTimeHelper.DateTimeToStamp(DateTime.UtcNow));

    public static ApiResult<T> Failure() 
        => new(false, StatusCode.Failure, "Failure", requestId: Guid.NewGuid(),
            timestamp: DateTimeHelper.DateTimeToStamp(DateTime.UtcNow));

    public static ApiResult<T> Failure(string? message) 
        => new(false, StatusCode.Failure, message, requestId: Guid.NewGuid(), 
            timestamp: DateTimeHelper.DateTimeToStamp(DateTime.UtcNow));

    public static ApiResult<T> Failure(int code, string? message) 
        => new(false, code, message, requestId: Guid.NewGuid(), 
            timestamp: DateTimeHelper.DateTimeToStamp(DateTime.UtcNow));
}