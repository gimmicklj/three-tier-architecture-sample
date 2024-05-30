namespace WebApi.Common.Result
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }

        public int Code { get; private set; }

        public string? Message { get; private set; }


        public T? Data { get; private set; }

        private Result(bool isSuccess, int code, string? message, T? data = default)
        {
            IsSuccess = isSuccess;
            Code = code;
            Message = message;
            Data = data;
        }

        public static Result<T> Ok() => new(true, StatusCode.Success, "Success");
        public static Result<T> Ok(string message) => new(true, StatusCode.Success, message);
        public static Result<T> Ok(T data) => new(true, StatusCode.Success, "Success", data);

        public static Result<T> Failure() => new(false, StatusCode.Failure, "Failure");
        public static Result<T> Failure(string? message) => new(false, StatusCode.Failure, message);

        public static Result<T> Failure(int code, string? message) => new(false, code, message);
    }
}
