# ISimpleHttpClient

The `ISimpleHttpClient` interface defines a simplified, reusable HTTP client for performing common HTTP operations such as `GET`, `POST`, `PATCH`, `PUT`, and `DELETE`. This abstraction helps encapsulate HTTP communication logic and allows for better testability, such as mocking HTTP requests in unit tests.

## Table of Contents

- [Features](#features)
- [Interface Definition](#interface-definition)
- [Usage Examples](#usage-examples)
  - [GET Request](#get-request)
  - [POST Request](#post-request)
  - [PATCH Request](#patch-request)
  - [PUT Request](#put-request)
  - [DELETE Request](#delete-request)
- [Exception Handling](#exception-handling)
- [Testing](#testing)
- [Installation](#installation)

## Features

- Supports HTTP methods: `GET`, `POST`, `PATCH`, `PUT`, `DELETE`
- Handles query parameters for `GET` requests
- Generic methods for automatic deserialization of responses
- Easy to mock and test in unit tests
- Exception handling for HTTP errors using a custom `SimpleHttpRequestException`

## Interface Definition

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
