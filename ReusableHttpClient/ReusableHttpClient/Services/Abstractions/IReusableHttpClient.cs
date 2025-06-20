namespace ReusableHttpClient.Services.Abstractions;

public interface IReusableHttpClient
{
    Task<TResult?> GetAsync<TResult>(string relativePath);
    Task<string> PostAsync<TResult>(string relativePath, TResult payload);
    Task<string> PostAsync(string relativePath);
    Task<TResponse?> PostAsync<TResult, TResponse>(string relativePath, TResult payload);
    Task<string> PatchAsync<TResult>(string relativePath, TResult payload);
    Task<TResponse?> PatchAsync<TResult, TResponse>(string relativePath, TResult payload);
    Task<string> PutAsync<TResult>(string relativePath, TResult payload);
    Task<TResponse?> PutAsync<TResult, TResponse>(string relativePath, TResult payload);
    Task<string> DeleteAsync(string relativePath);
    Task<string> DeleteAsync<TResult>(string relativePath, TResult payload);
    public void ClearAuthorizationHeader(string scheme);
    public void SetAuthorizationHeader(string scheme, string value);
    void SetDefaultHttpClient(string clientName);
}