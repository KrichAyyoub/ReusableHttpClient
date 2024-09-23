# ReusableHttpClient NuGet Package

`ReusableHttpClient` is a reusable HTTP client abstraction that simplifies making HTTP requests (`GET`, `POST`, `PATCH`, `PUT`, `DELETE`). It integrates easily with Dependency Injection (DI) in .NET and provides a mockable interface for unit testing.

## Installation

Install the package via the .NET CLI:

```bash
dotnet add package ReusableHttpClient
```

Or via NuGet Package Manager:

```powershell
Install-Package ReusableHttpClient
```

Register `ReusableHttpClient` in your DI container:

```csharp
services.AddReusableHttpClient("https://api.restful-api.dev");
```

## Features

- **Supports common HTTP methods**: `GET`, `POST`, `PATCH`, `PUT`, `DELETE`
- **Handles query parameters** in `GET` requests
- **Generic response deserialization** for strongly-typed models
- **Custom exception handling** via `ReusableHttpRequestException`
- **Easily testable** using the `IReusableHttpClient` interface

## Interface

```csharp
public interface IReusableHttpClient
{
    Task<TResult?> GetAsync<TResult>(string relativePath);
    Task<string> PostAsync<TResult>(string relativePath, TResult payload);
    Task<TResponse?> PostAsync<TResult, TResponse>(string relativePath, TResult payload);
    Task<string> PatchAsync<TResult>(string relativePath, TResult payload);
    Task<TResponse?> PatchAsync<TResult, TResponse>(string relativePath, TResult payload);
    Task<string> PutAsync<TResult>(string relativePath, TResult payload);
    Task<TResponse?> PutAsync<TResult, TResponse>(string relativePath, TResult payload);
    Task<string> DeleteAsync(string relativePath);
    Task<string> DeleteAsync<TResult>(string relativePath, TResult payload);
    void ClearAuthorizationHeader(string scheme);
    void SetAuthorizationHeader(string scheme, string value);
}
```

## Usage Examples

### GET Request

```csharp
var response = await ReusableHttpClient.GetAsync<MyResponseModel>("/api/data");
```

With query parameters:

```csharp
var queryParams = new Dictionary<string, string> { { "id", "123" } };
var response = await ReusableHttpClient.GetAsync<MyResponseModel>("/api/data", queryParams);
```

### POST Request

```csharp
var payload = new MyRequestModel { Data = "Sample data" };
var response = await ReusableHttpClient.PostAsync<MyRequestModel, MyResponseModel>("/api/data", payload);
```

### PATCH Request

```csharp
var payload = new MyRequestModel { Data = "Updated data" };
await ReusableHttpClient.PatchAsync("/api/data/123", payload);
```

### PUT Request

```csharp
var payload = new MyRequestModel { Data = "New data" };
await ReusableHttpClient.PutAsync("/api/data/123", payload);
```

### DELETE Request

```csharp
await ReusableHttpClient.DeleteAsync("/api/data/123");
```

### ClearAuthorizationHeader

```csharp
ClearAuthorizationHeader(JwtBearerDefaults.AuthenticationScheme)

```

### SetAuthorizationHeader

```csharp
SetAuthorizationHeader(JwtBearerDefaults.AuthenticationScheme , "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c")

```

## Exception Handling

`ReusableHttpRequestException` captures the HTTP status code and response body:

```csharp
try
{
    var result = await ReusableHttpClient.GetAsync<MyResponseModel>("/api/data/123");
}
catch (ReusableHttpRequestException ex)
{
    Console.WriteLine(`Error: ${ex.StatusCode} - ${ex.Message}`);
}
```

## Testing

Mock `IReusableHttpClient` using libraries like `NSubstitute` for unit testing:

```csharp
var mockClient = Substitute.For<IReusableHttpClient>();
mockClient.GetAsync<MyResponseModel>("/api/data")
    .Returns(new MyResponseModel { Data = "Sample data" });
```

## License

Licensed under the [MIT License](LICENSE)."