namespace HAsystem.Dents.Core;

//public class ApiException : Exception
//{
//    public string Category { get; }

//    public ApiException(string message, string category) : base(message)
//    {
//        Category = category;
//    }

//    public override string ToString() => $"Error: {Message} | Categoría: {Category}";
//}
public class ApiException : Exception
{
    public string Category { get; }
    public int StatusCode { get; }
    public IEnumerable<CustomErrorCode>? Errors { get; }

    public ApiException(string message, string category, int statusCode, IEnumerable<CustomErrorCode>? errors = null)
        : base(message)
    {
        Category = category;
        StatusCode = statusCode;
        Errors = errors ?? new List<CustomErrorCode> { new CustomErrorCode("ERR500", "Error desconocido", "Sistema") };
    }

    public override string ToString() => $"Error: {Message} | Categoría: {Category} | Código HTTP: {StatusCode}";
}
