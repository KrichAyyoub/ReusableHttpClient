namespace StupidHttpClient.Tests;

public class StupidHttpClientInterfaceTests
{
    private readonly IStupidHttpClient _stupidHttpClient;

    public StupidHttpClientInterfaceTests()
    {
        _stupidHttpClient = Substitute.For<IStupidHttpClient>();
    }

    [Fact]
    public async Task GetAsync_ShouldReturnResult()
    {
        // Arrange
        TestResponse expectedResult = new TestResponse { Id = 1, Name = "Test" };
        _stupidHttpClient.GetAsync<TestResponse>("api/test")!.Returns(Task.FromResult(expectedResult));

        // Act
        TestResponse? result = await _stupidHttpClient.GetAsync<TestResponse>("api/test");

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task PostAsync_ShouldReturnString()
    {
        // Arrange
        TestRequest payload = new TestRequest { Name = "Test" };
        string expectedResult = "Success";
        _stupidHttpClient.PostAsync("api/test", payload).Returns(Task.FromResult(expectedResult));

        // Act
        string result = await _stupidHttpClient.PostAsync("api/test", payload);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public async Task PostAsync_WithResponse_ShouldReturnResult()
    {
        // Arrange
        TestRequest payload = new TestRequest { Name = "Test" };
        TestResponse expectedResult = new TestResponse { Id = 1, Name = "Test" };
        _stupidHttpClient.PostAsync<TestRequest, TestResponse>("api/test", payload)!.Returns(
            Task.FromResult(expectedResult));

        // Act
        TestResponse? result = await _stupidHttpClient.PostAsync<TestRequest, TestResponse>("api/test", payload);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task PatchAsync_ShouldReturnString()
    {
        // Arrange
        TestRequest payload = new TestRequest { Name = "Test" };
        string expectedResult = "Success";
        _stupidHttpClient.PatchAsync("api/test", payload).Returns(Task.FromResult(expectedResult));

        // Act
        string result = await _stupidHttpClient.PatchAsync("api/test", payload);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public async Task PatchAsync_WithResponse_ShouldReturnResult()
    {
        // Arrange
        TestRequest payload = new TestRequest { Name = "Test" };
        TestResponse expectedResult = new TestResponse { Id = 1, Name = "Test" };
        _stupidHttpClient.PatchAsync<TestRequest, TestResponse>("api/test", payload)!.Returns(
            Task.FromResult(expectedResult));

        // Act
        TestResponse? result = await _stupidHttpClient.PatchAsync<TestRequest, TestResponse>("api/test", payload);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task PutAsync_ShouldReturnString()
    {
        // Arrange
        TestRequest payload = new TestRequest { Name = "Test" };
        string expectedResult = "Success";
        _stupidHttpClient.PutAsync("api/test", payload).Returns(Task.FromResult(expectedResult));

        // Act
        string result = await _stupidHttpClient.PutAsync("api/test", payload);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public async Task PutAsync_WithResponse_ShouldReturnResult()
    {
        // Arrange
        TestRequest payload = new TestRequest { Name = "Test" };
        TestResponse expectedResult = new TestResponse { Id = 1, Name = "Test" };
        _stupidHttpClient.PutAsync<TestRequest, TestResponse>("api/test", payload)!.Returns(
            Task.FromResult(expectedResult));

        // Act
        TestResponse? result = await _stupidHttpClient.PutAsync<TestRequest, TestResponse>("api/test", payload);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnString()
    {
        // Arrange
        string expectedResult = "Success";
        _stupidHttpClient.DeleteAsync("api/test").Returns(Task.FromResult(expectedResult));

        // Act
        string result = await _stupidHttpClient.DeleteAsync("api/test");

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public async Task DeleteAsync_WithPayload_ShouldReturnString()
    {
        // Arrange
        TestRequest payload = new TestRequest { Name = "Test" };
        string expectedResult = "Success";
        _stupidHttpClient.DeleteAsync("api/test", payload).Returns(Task.FromResult(expectedResult));

        // Act
        string result = await _stupidHttpClient.DeleteAsync("api/test", payload);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void ClearAuthorizationHeader_ShouldClearHeader()
    {
        // Arrange
        string scheme = "Bearer";

        // Act
        _stupidHttpClient.ClearAuthorizationHeader(scheme);

        // Assert
        _stupidHttpClient.Received(1).ClearAuthorizationHeader(scheme);
    }

    [Fact]
    public void SetAuthorizationHeader_ShouldSetHeader()
    {
        // Arrange
        string scheme = "Bearer";
        string value = "token";

        // Act
        _stupidHttpClient.SetAuthorizationHeader(scheme, value);

        // Assert
        _stupidHttpClient.Received(1).SetAuthorizationHeader(scheme, value);
    }
}