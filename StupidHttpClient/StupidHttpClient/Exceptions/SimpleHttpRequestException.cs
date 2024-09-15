namespace StupidHttpClient.Exceptions;

public class SimpleHttpRequestException : HttpRequestException
{
    public new HttpStatusCode StatusCode { get; set; }
    public string ResponseBody { get; set; }

    public SimpleHttpRequestException(HttpStatusCode statusCode, string responseBody)
    {
        StatusCode = statusCode;
        ResponseBody = responseBody;
    }
}