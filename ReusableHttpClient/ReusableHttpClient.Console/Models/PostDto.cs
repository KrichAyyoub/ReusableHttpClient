﻿namespace ReusableHttpClient.Console.Models;

public class PostDto
{
    [JsonProperty("id")] public int? Id { get; set; }

    [JsonProperty("title")] public string? Title { get; set; }

    [JsonProperty("body")] public string? Body { get; set; }

    [JsonProperty("userId")] public int UserId { get; set; }
}