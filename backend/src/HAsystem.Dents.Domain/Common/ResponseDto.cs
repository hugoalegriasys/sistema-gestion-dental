namespace HAsystem.Dents.Domain.Common;

public class ResponseDto<T>
{
    public bool Status { get; set; }
    public IEnumerable<T>? Lista { get; set; }
    public T? registro { get; set; }

}
