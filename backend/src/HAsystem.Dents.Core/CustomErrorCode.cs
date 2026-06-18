namespace HAsystem.Dents.Core;
public  class CustomErrorCode
{
    public string Code { get; }
    public string Message { get; }
    public string Category { get; }

    public CustomErrorCode(string code, string message, string category)
    {
        Code = code;
        Message = message;
        Category = category;
    }
}
