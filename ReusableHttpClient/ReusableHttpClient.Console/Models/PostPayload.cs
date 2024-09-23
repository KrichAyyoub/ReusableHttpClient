namespace ReusableHttpClient.Console.Models;

public class PostPayload
{
    [JsonProperty("title")] public string? Title { get; set; }

    [JsonProperty("body")] public string? Body { get; set; }

    [JsonProperty("userId")] public int UserId { get; set; }
}