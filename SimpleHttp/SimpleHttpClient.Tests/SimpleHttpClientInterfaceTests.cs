namespace SimpleHttpClient.Tests;

public class SimpleHttpClientInterfaceTests
{
    private readonly ISimpleHttpClient _simpleHttpClient;

    public SimpleHttpClientInterfaceTests()
    {
        _simpleHttpClient = Substitute.For<ISimpleHttpClient>();
    }

    [Fact]
    public async Task GetAsync_WithValidResponse_ShouldReturnDeserializedResult()
    {
        // Arrange
        var relativePath = "/test-path";
        var expectedResponse = new TestResponse { Data = "TestData" };

        _simpleHttpClient.GetAsync<TestResponse>(relativePath)!
            .Returns(Task.FromResult(expectedResponse));

        // Act
        var result = await _simpleHttpClient.GetAsync<TestResponse>(relativePath);

        // Assert
        result.Should().NotBeNull();
        result?.Data.Should().Be(expectedResponse.Data);
    }

    [Fact]
    public async Task GetAsync_WithQueryParams_ShouldReturnResult()
    {
        // Arrange
        var relativePath = "/test-path";
        var queryParams = new Dictionary<string, string> { { "key", "value" } };
        var expectedResponse = new TestResponse { Data = "TestData" };

        _simpleHttpClient.GetAsync<TestResponse>(relativePath, queryParams)!
            .Returns(Task.FromResult(expectedResponse));

        // Act
        var result = await _simpleHttpClient.GetAsync<TestResponse>(relativePath, queryParams);

        // Assert
        result.Should().NotBeNull();
        result?.Data.Should().Be(expectedResponse.Data);
    }

    [Fact]
    public async Task PostAsync_WithValidPayload_ShouldReturnResponseBody()
    {
        // Arrange
        var relativePath = "/test-path";
        var payload = new TestRequest { Data = "TestData" };
        var expectedResponse = "response body";

        _simpleHttpClient.PostAsync(relativePath, payload)
            .Returns(Task.FromResult(expectedResponse));

        // Act
        var result = await _simpleHttpClient.PostAsync(relativePath, payload);

        // Assert
        result.Should().Be(expectedResponse);
    }

    [Fact]
    public async Task PatchAsync_WithValidPayload_ShouldReturnResponseBody()
    {
        // Arrange
        var relativePath = "/test-path";
        var payload = new TestRequest { Data = "TestData" };
        var expectedResponse = "patched response";

        _simpleHttpClient.PatchAsync(relativePath, payload)
            .Returns(Task.FromResult(expectedResponse));

        // Act
        var result = await _simpleHttpClient.PatchAsync(relativePath, payload);

        // Assert
        result.Should().Be(expectedResponse);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnResponseBody()
    {
        // Arrange
        var relativePath = "/test-path";
        var expectedResponse = "deleted";

        _simpleHttpClient.DeleteAsync(relativePath)
            .Returns(Task.FromResult(expectedResponse));

        // Act
        var result = await _simpleHttpClient.DeleteAsync(relativePath);

        // Assert
        result.Should().Be(expectedResponse);
    }

    [Fact]
    public async Task GetAsync_WithHttpRequestException_ShouldThrowSimpleHttpRequestException()
    {
        // Arrange
        var relativePath = "/test-path";
        var expectedException = new SimpleHttpRequestException(HttpStatusCode.BadRequest, "Network error");

        _simpleHttpClient.GetAsync<TestResponse>(relativePath)
            .Returns<Task<TestResponse?>>(_ => throw expectedException);

        // Act
        Func<Task> act = async () => await _simpleHttpClient.GetAsync<TestResponse>(relativePath);

        // Assert
        await act.Should().ThrowAsync<SimpleHttpRequestException>();
    }

    [Fact]
    public async Task PutAsync_WithValidPayload_ShouldReturnResponseBody()
    {
        // Arrange
        var relativePath = "/test-path";
        var payload = new TestRequest { Data = "TestData" };
        var expectedResponse = "put response";

        _simpleHttpClient.PutAsync(relativePath, payload)
            .Returns(Task.FromResult(expectedResponse));

        // Act
        var result = await _simpleHttpClient.PutAsync(relativePath, payload);

        // Assert
        result.Should().Be(expectedResponse);
    }
}