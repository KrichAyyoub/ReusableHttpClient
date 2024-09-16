namespace StupidHttpClient.Services.Abstractions;

public interface IStupidHttpClient
{
    Task<TResult?> GetAsync<TResult>(string relativePath);
    Task<string> PostAsync<TResult>(string relativeRoute, TResult payload);
    Task<TResponse?> PostAsync<TResult, TResponse>(string relativeRoute, TResult payload);
    Task<string> PatchAsync<TResult>(string relativeRoute, TResult payload);
    Task<TResponse?> PatchAsync<TResult, TResponse>(string relativeRoute, TResult payload);
    Task<string> PutAsync<TResult>(string relativeRoute, TResult payload);
    Task<TResponse?> PutAsync<TResult, TResponse>(string relativeRoute, TResult payload);
    Task<string> DeleteAsync(string relativeRoute);
    Task<string> DeleteAsync<TResult>(string relativeRoute, TResult payload);
    public void ClearAuthorizationHeader(string scheme);
    public void SetAuthorizationHeader(string scheme, string value);
}