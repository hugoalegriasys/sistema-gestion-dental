using Microsoft.AspNetCore.Http;
using System.Data;
using System.Net;


namespace HAsystem.Dents.Core;

public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public CustomErrorCode? ErrorCode { get; }
    public IEnumerable<CustomErrorCode>? Errordetails { get; }
    private Result(T value) { IsSuccess = true; Value = value; }
    private Result(CustomErrorCode errorCode) { IsSuccess = false; ErrorCode = errorCode; }
    private Result(IEnumerable<CustomErrorCode> errors)
    {
        IsSuccess = false;
        Value = default;
        Errordetails = errors ?? new List<CustomErrorCode>(); // Evita `null`
    }
    public static Result<T> Success(T value) => new(value);
    public static Result<T> Failure(CustomErrorCode  ErrorCode) => new(ErrorCode);
    public static Result<T> Failure(CustomErrorCode errorCode,IEnumerable<CustomErrorCode> errors) => new(errors);
    public IResult MatchApiException(Func<T, IResult> onSuccess, Func<ApiException, IResult> onFailure)
    {
        if (IsSuccess)
            return onSuccess(Value!);

        if (Errordetails?.Any() == true)
        {
            var first = Errordetails.First();
            return onFailure(new ApiException(
                first.Message ?? "Error de validación",
                first.Category ?? "Validacion",
                (int)HttpStatusCode.BadRequest,
                Errordetails));
        }

        if (ErrorCode is not null)
        {
            return onFailure(new ApiException(
                ErrorCode.Message,
                ErrorCode.Category,
                (int)HttpStatusCode.BadRequest,
                null));
        }

        return onFailure(new ApiException(
            "Error desconocido",
            "Sistema",
            (int)HttpStatusCode.InternalServerError,
            null));
    }
}
