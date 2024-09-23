// See https://aka.ms/new-console-template for more information

using ReusableHttpClient.Exceptions;

ServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.AddReusableHttpClient("https://jsonplaceholder.typicode.com");
ServiceProvider services = serviceCollection.BuildServiceProvider();

IReusableHttpClient reusableHttpClient = services.GetRequiredService<IReusableHttpClient>();

// GET Async
List<PostDto>? listOfObjects = await reusableHttpClient.GetAsync<List<PostDto>>("posts");
Console.WriteLine($"{nameof(listOfObjects)} : {JsonConvert.SerializeObject(listOfObjects)}");


// GET Async by id 

PostDto? resultById = await reusableHttpClient.GetAsync<PostDto>("posts/1");

Console.WriteLine($"{nameof(resultById)} : {JsonConvert.SerializeObject(resultById)}");

// Post Async

PostPayload payload = new()
{
    Title = "Hello World!",
    Body = "lorem ipsum dolor sit amet",
    UserId = 1
};

PostDto? postResult = await reusableHttpClient.PostAsync<PostPayload, PostDto>("posts", payload);
Console.WriteLine($"{nameof(postResult)} : : {JsonConvert.SerializeObject(postResult)}");

PostDto? createdObject =
    await reusableHttpClient.GetAsync<PostDto>($"posts/1");

Console.WriteLine($"{nameof(createdObject)} : {JsonConvert.SerializeObject(createdObject)}");

// PUT Async

PostDto putPayload = new PostDto()
{
    Title = "Hello World V2",
    Body = "lorem ipsum dolor sit amet",
    UserId = 1
};

PostDto? putResult = await reusableHttpClient.PutAsync<PostDto, PostDto>($"posts/1", putPayload);
Console.WriteLine($"{nameof(putResult)} : {JsonConvert.SerializeObject(putResult)}");

// Patch Async 

PostDto patchPayload = new PostDto()
{
    Title = "hello World V3",
};

PostDto? patchResult = await reusableHttpClient.PatchAsync<PostDto, PostDto>($"posts/1", patchPayload);
Console.WriteLine($"{nameof(patchResult)} : {JsonConvert.SerializeObject(patchResult)}");

// Delete Async 

string deleteResult = await reusableHttpClient.DeleteAsync($"posts/1");
Console.WriteLine($"{nameof(deleteResult)} : {JsonConvert.SerializeObject(deleteResult)}");