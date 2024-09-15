## SimpleHttpClient

The \`SimpleHttpClient\` NuGet package provides a simplified and reusable HTTP client for performing common HTTP operations like \`GET\`, \`POST\`, \`PATCH\`, \`PUT\`, and \`DELETE\`. It abstracts HTTP communication logic and offers seamless integration with Dependency Injection (DI), and is easy to mock for unit testing.

## Table of Contents

- [Installation](#installation)
- [Features](#features)
- [Interface Definition](#interface-definition)
- [Usage Examples](#usage-examples)
  - [GET Request](#get-request)
- [SimpleHttpClient](#simplehttpclient)

## Installation

To install the \`SimpleHttpClient\` package, run the following command in the Package Manager Console:

\`\`\`powershell
Install-Package SimpleHttpClient
\`\`\`

## Features

- Simplified HTTP client for common operations
- Supports \`GET\`, \`POST\`, \`PATCH\`, \`PUT\`, and \`DELETE\` methods
- Seamless integration with Dependency Injection (DI)
- Easy to mock for unit testing
- Handles common HTTP errors and exceptions

## Interface Definition

The \`SimpleHttpClient\` interface defines the following methods:

\`\`\`csharp
public interface ISimpleHttpClient
{
    Task<HttpResponseMessage> GetAsync(string requestUri);
    Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);
    Task<HttpResponseMessage> PatchAsync(string requestUri, HttpContent content);
    Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content);
    Task<HttpResponseMessage> DeleteAsync(string requestUri);
}
\`\`\`

## Usage Examples

### GET Request

\`\`\`csharp
var response = await simpleHttpClient.GetAsync(\"https://api.example.com/data\");
\`\`\`

### POST Request

\`\`\`csharp
var content = new StringContent(jsonData, Encoding.UTF8, \"application/json\");
var response = await simpleHttpClient.PostAsync(\"https://api.example.com/data\", content);
\`\`\`

### PATCH Request

\`\`\`csharp
var content = new StringContent(jsonData, Encoding.UTF8, \"application/json\");
var response = await simpleHttpClient.PatchAsync(\"https://api.example.com/data\", content);
\`\`\`

### PUT Request

\`\`\`csharp
var content = new StringContent(jsonData, Encoding.UTF8, \"application/json\");
var response = await simpleHttpClient.PutAsync(\"https://api.example.com/data\", content);
\`\`\`

### DELETE Request

\`\`\`csharp
var response = await simpleHttpClient.DeleteAsync(\"https://api.example.com/data\");
\`\`\`

## Exception Handling

The \`SimpleHttpClient\` handles common HTTP errors and exceptions, providing meaningful error messages and status codes. It throws custom exceptions for different HTTP status codes, making it easier to handle errors in your application.
