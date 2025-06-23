namespace ReusableHttpClient.Services;

public class ReusableHttpClient : IReusableHttpClient
{
    private readonly ILogger<ReusableHttpClient> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private HttpClient _httpClient;

    public ReusableHttpClient(ILogger<ReusableHttpClient> logger,
        IHttpClientFactory httpClientFactory, HttpClient httpClient)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _httpClient = httpClient;
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
            StringContent content = new(json, Encoding.UTF8, MediaTypes.ApplicationJson);
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

    public async Task<string> PostAsync(string relativePath)
    {
        HttpStatusCode statusCode = HttpStatusCode.OK;
        string responseBody = string.Empty;

        try
        {
            HttpResponseMessage response = await _httpClient.PostAsync(relativePath, default);

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
            StringContent content = new(json, Encoding.UTF8, MediaTypes.ApplicationJson);
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
            StringContent content = new(json, Encoding.UTF8, MediaTypes.ApplicationJson);
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
            StringContent content = new(json, Encoding.UTF8, MediaTypes.ApplicationJson);
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
            StringContent content = new(json, Encoding.UTF8, MediaTypes.ApplicationJson);
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
            StringContent content = new(json, Encoding.UTF8, MediaTypes.ApplicationJson);
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
            StringContent content = new(json, Encoding.UTF8, MediaTypes.ApplicationJson);
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

    public void AddHeaderKeyValue(string name, string value)
    {
        _httpClient.DefaultRequestHeaders.Add(name, value);
    }

    public void SetDefaultHttpClient(string clientName)
    {
        _httpClient.Dispose();
        _httpClient = _httpClientFactory.CreateClient(clientName);
    }

    public void ClearAuthorizationHeader(string scheme)
    {
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(scheme, string.Empty);
    }

    public void SetAuthorizationHeader(string scheme, string value)
    {
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(scheme, value);
    }

    private void LogHttpRequestException(HttpRequestException ex)
    {
        _logger.LogError("error occured {statusCode} : {message}", ex.StatusCode, ex.Message);
    }
}