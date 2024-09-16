namespace StupidHttpClient.Console.Models;

public class Data
{
    [JsonProperty("color")]
    public string? Color { get; set; }

    [JsonProperty("capacity")]
    public string? Capacity { get; set; }
}

public class ObjectDto
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("data")]
    public Data? Data { get; set; }
}