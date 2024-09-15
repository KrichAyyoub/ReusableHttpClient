using StupidHttpClient.Exceptions;

namespace StupidHttpClient.Services;

public interface IStupidHttpClient
{
    Task<TResult?> GetAsync<TResult>(string relativePath, Dictionary<string, string> queryParams);
    Task<TResult?> GetAsync<TResult>(string relativePath);
    Task<string> PostAsync<TResult>(string relativeRoute, TResult payload);
    Task<TResponse?> PostAsync<TResult, TResponse>(string relativeRoute, TResult payload);
    Task<string> PatchAsync<TResult>(string relativeRoute, TResult payload);
    Task<TResponse?> PatchAsync<TResult, TResponse>(string relativeRoute, TResult payload);
    
    Task<string> PutAsync<TResult>(string relativeRoute, TResult payload);
    Task<TResponse?> PutAsync<TResult, TResponse>(string relativeRoute, TResult payload);
    Task<string> DeleteAsync(string relativeRoute);
    Task<string> DeleteAsync<TResult>(string relativeRoute, TResult payload);
}

public class StupidHttpClient : IStupidHttpClient
{
    private readonly ILogger<StupidHttpClient> _logger;
    private readonly HttpClient _httpClient;

    public StupidHttpClient(ILogger<StupidHttpClient> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    public async Task<TResult?> GetAsync<TResult>(string relativePath, Dictionary<string, string> queryParams)
    {
        HttpStatusCode statusCode = HttpStatusCode.OK;
        string responseBody = string.Empty;

        string? query = GetQueryFromQueryParams(queryParams);

        if (query is not null)
            relativePath = $"{relativePath}{query}";

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(relativePath);

            statusCode = response.StatusCode;
            responseBody = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            TResult? result = JsonConvert.DeserializeObject<TResult>(json);

            return result;
        }
        catch (HttpRequestException ex)
        {
            LogHttpRequestException(ex);
            throw new SimpleHttpRequestException(statusCode, responseBody);
        }
    }

    public async Task<TResult?> GetAsync<TResult>(string relativePath)
    {
        HttpStatusCode statusCode = HttpStatusCode.OK;
        string responseBody = string.Empty;

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(relativePath);

            statusCode = response.StatusCode;
            responseBody = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            TResult? result = JsonConvert.DeserializeObject<TResult>(json);

            return result;
        }
        catch (HttpRequestException ex)
        {
            LogHttpRequestException(ex);
            throw new SimpleHttpRequestException(statusCode, responseBody);
        }
    }

    public async Task<string> PostAsync<TResult>(string relativePath, TResult payload)
    {
        HttpStatusCode statusCode = HttpStatusCode.OK;
        string responseBody = string.Empty;

        try
        {
            string json = JsonConvert.SerializeObject(payload);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(relativePath, content);

            statusCode = response.StatusCode;
            responseBody = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            return responseBody;
        }
        catch (HttpRequestException ex)
        {
            LogHttpRequestException(ex);
            throw new SimpleHttpRequestException(statusCode, responseBody);
        }
    }

    public async Task<TResponse?> PostAsync<TResult, TResponse>(string relativePath, TResult payload)
    {
        HttpStatusCode statusCode = HttpStatusCode.OK;
        string responseBody = string.Empty;

        try
        {
            string json = JsonConvert.SerializeObject(payload);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(relativePath, content);

            statusCode = response.StatusCode;
            responseBody = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            
            TResponse? result = JsonConvert.DeserializeObject<TResponse>(responseBody);
            return result;
        }
        catch (HttpRequestException ex)
        {
            LogHttpRequestException(ex);
            throw new SimpleHttpRequestException(statusCode, responseBody);
        }
    }

    public async Task<string> PatchAsync<TResult>(string relativePath, TResult payload)
    {
        HttpStatusCode statusCode = HttpStatusCode.OK;
        string responseBody = string.Empty;

        try
        {
            string json = JsonConvert.SerializeObject(payload);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PatchAsync(relativePath, content);

            statusCode = response.StatusCode;
            responseBody = await response.Content.ReadAsStringAsync();
            
            response.EnsureSuccessStatusCode();
            return responseBody;
        }
        catch (HttpRequestException ex)
        {
            LogHttpRequestException(ex);
            throw new SimpleHttpRequestException(statusCode, responseBody);
        }
    }

    public async Task<TResponse?> PatchAsync<TResult, TResponse>(string relativePath, TResult payload)
    {
        HttpStatusCode statusCode = HttpStatusCode.OK;
        string responseBody = string.Empty;

        try
        {
            string json = JsonConvert.SerializeObject(payload);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PatchAsync(relativePath, content);

            statusCode = response.StatusCode;
            responseBody = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            TResponse? result = JsonConvert.DeserializeObject<TResponse>(responseBody);
            return result;
        }
        catch (HttpRequestException ex)
        {
            LogHttpRequestException(ex);
            throw new SimpleHttpRequestException(statusCode, responseBody);
        }
    }

    public async Task<string> PutAsync<TResult>(string relativePath, TResult payload)
    {
        HttpStatusCode statusCode = HttpStatusCode.OK;
        string responseBody = string.Empty;

        try
        {
            string json = JsonConvert.SerializeObject(payload);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(relativePath, content);

            statusCode = response.StatusCode;
            responseBody = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            return responseBody;
        }
        catch (HttpRequestException ex)
        {
            LogHttpRequestException(ex);
            throw new SimpleHttpRequestException(statusCode, responseBody);
        }
    }

    public async Task<TResponse?> PutAsync<TResult, TResponse>(string relativePath, TResult payload)
    {
        HttpStatusCode statusCode = HttpStatusCode.OK;
        string responseBody = string.Empty;

        try
        {
            string json = JsonConvert.SerializeObject(payload);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(relativePath, content);

            statusCode = response.StatusCode;
            responseBody = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();

            TResponse? result = JsonConvert.DeserializeObject<TResponse>(responseBody);
            return result;
        }
        catch (HttpRequestException ex)
        {
            LogHttpRequestException(ex);
            throw new SimpleHttpRequestException(statusCode, responseBody);
        }
    }

    public async Task<string> DeleteAsync(string relativePath)
    {
        HttpStatusCode statusCode = HttpStatusCode.OK;
        string responseBody = string.Empty;

        try
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(relativePath);

            statusCode = response.StatusCode;
            responseBody = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            return responseBody;
        }
        catch (HttpRequestException ex)
        {
            LogHttpRequestException(ex);
            throw new SimpleHttpRequestException(statusCode, responseBody);
        }
    }

    public async Task<string> DeleteAsync<TResult>(string relativePath, TResult payload)
    {
        HttpStatusCode statusCode = HttpStatusCode.OK;
        string responseBody = string.Empty;

        try
        {
            string json = JsonConvert.SerializeObject(payload);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(relativePath, content);

            statusCode = response.StatusCode;
            responseBody = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            
            return responseBody;
        }
        catch (HttpRequestException ex)
        {
            LogHttpRequestException(ex);
            throw new SimpleHttpRequestException(statusCode, responseBody);
        }
    }

    private static string? GetQueryFromQueryParams(Dictionary<string, string> queryParams)
    {
        if (queryParams.Count == 0)
            return null;

        StringBuilder queryBuilder = new();

        foreach (var item in queryParams.Select((value, index) => new { index, value }))
        {
            if (item.index == 0)
            {
                queryBuilder.Append($"?{item.value.Key}={item.value.Value}");
                continue;
            }

            queryBuilder.Append($"&{item.value.Key}={item.value.Value}");
        }

        return queryBuilder.Length == 0 ? null : queryBuilder.ToString();
    }

    private void LogHttpRequestException(HttpRequestException ex)
    {
        _logger.LogError("error occured {statusCode} : {message}", ex.StatusCode, ex.Message);
    }
}