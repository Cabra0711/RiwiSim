namespace LogisticMVP.Response;

public class ServiceResponse<T>
{
    public string Message { get; set; } = string.Empty;
    public T Data { get; set; }
    public bool Success { get; set; }
}