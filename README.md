# SimpleHttpClient NuGet Package

`SimpleHttpClient` is a reusable HTTP client abstraction that simplifies making HTTP requests (`GET`, `POST`, `PATCH`, `PUT`, `DELETE`). It integrates easily with Dependency Injection (DI) in .NET and provides a mockable interface for unit testing.

## Installation

Install the package via the .NET CLI:

```bash
dotnet add package SimpleHttpClient
```

Or via NuGet Package Manager:

```powershell
Install-Package SimpleHttpClient
```

Register `SimpleHttpClient` in your DI container:

```csharp
services.AddSimpleHttpClient(baseAddress:"https://api.dev");
```

## Features

- **Supports common HTTP methods**: `GET`, `POST`, `PATCH`, `PUT`, `DELETE`
- **Handles query parameters** in `GET` requests
- **Generic response deserialization** for strongly-typed models
- **Custom exception handling** via `SimpleHttpRequestException`
- **Easily testable** using the `ISimpleHttpClient` interface

## Interface

```csharp
public interface ISimpleHttpClient
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
```

## Usage Examples

### GET Request

```csharp
var response = await simpleHttpClient.GetAsync<MyResponseModel>("/api/data");
```

With query parameters:

```csharp
var queryParams = new Dictionary<string, string> { { "id", "123" } };
var response = await simpleHttpClient.GetAsync<MyResponseModel>("/api/data", queryParams);
```

### POST Request

```csharp
var payload = new MyRequestModel { Data = "Sample data" };
var response = await simpleHttpClient.PostAsync<MyRequestModel, MyResponseModel>("/api/data", payload);
```

### PATCH Request

```csharp
var payload = new MyRequestModel { Data = "Updated data" };
await simpleHttpClient.PatchAsync("/api/data/123", payload);
```

### PUT Request

```csharp
var payload = new MyRequestModel { Data = "New data" };
await simpleHttpClient.PutAsync("/api/data/123", payload);
```

### DELETE Request

```csharp
await simpleHttpClient.DeleteAsync("/api/data/123");
```

## Exception Handling

`SimpleHttpRequestException` captures the HTTP status code and response body:

```csharp
try
{
    var result = await simpleHttpClient.GetAsync<MyResponseModel>("/api/data/123");
}
catch (SimpleHttpRequestException ex)
{
    Console.WriteLine(`Error: ${ex.StatusCode} - ${ex.Message}`);
}
```

## Testing

Mock `ISimpleHttpClient` using libraries like `NSubstitute` for unit testing:

```csharp
var mockClient = Substitute.For<ISimpleHttpClient>();
mockClient.GetAsync<MyResponseModel>("/api/data")
    .Returns(new MyResponseModel { Data = "Sample data" });
```

## License

Licensed under the [MIT License](LICENSE)."