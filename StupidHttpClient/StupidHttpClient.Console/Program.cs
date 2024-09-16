// See https://aka.ms/new-console-template for more information

ServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.AddStupidHttpClient("https://api.restful-api.dev");
ServiceProvider services = serviceCollection.BuildServiceProvider();

IStupidHttpClient stupidHttpClient = services.GetRequiredService<IStupidHttpClient>();

// GET Async
List<ObjectDto>? listOfObjects = await stupidHttpClient.GetAsync<List<ObjectDto>>("objects");

Console.WriteLine($"{nameof(listOfObjects)} : {JsonConvert.SerializeObject(listOfObjects)}");

// GET Async by id 

ObjectDto? resultById = await stupidHttpClient.GetAsync<ObjectDto>("https://api.restful-api.dev/objects/7");

Console.WriteLine($"{nameof(resultById)} : {JsonConvert.SerializeObject(resultById)}");

// Post Async

ObjectDto payload = new ObjectDto()
{
    Name = "Apple MacBook Pro 16",
    Data = new Data()
    {
        Color = "White",
        Capacity = "255MB"
    }
};

ObjectDto? postResult = await stupidHttpClient.PostAsync<ObjectDto , ObjectDto>("objects", payload);
Console.WriteLine($"{nameof(postResult)} : : {JsonConvert.SerializeObject(postResult)}");

ObjectDto? createdObject = await stupidHttpClient.GetAsync<ObjectDto>($"https://api.restful-api.dev/objects/{postResult?.Id}");

Console.WriteLine($"{nameof(createdObject)} : {JsonConvert.SerializeObject(createdObject)}");

// PUT Async

ObjectDto putPayload = new ObjectDto()
{
    Name = "Apple MacBook Pro 15",
    Data = new Data()
    {
        Color = "Black",
        Capacity = "256MB"
    }
};

ObjectDto? putResult = await stupidHttpClient.PutAsync<ObjectDto , ObjectDto>($"objects/{createdObject?.Id}", putPayload);
Console.WriteLine($"{nameof(putResult)} : {JsonConvert.SerializeObject(putResult)}");

// Patch Async 

ObjectDto patchPayload = new ObjectDto()
{
    Name = "Apple MacBook Pro 200",
};

ObjectDto? patchResult = await stupidHttpClient.PatchAsync<ObjectDto , ObjectDto>($"objects/{putResult?.Id}", patchPayload);
Console.WriteLine($"{nameof(patchResult)} : {JsonConvert.SerializeObject(patchResult)}");

// Delete Async 

string deleteResult = await stupidHttpClient.DeleteAsync($"objects/{patchResult?.Id}");
Console.WriteLine($"{nameof(deleteResult)} : {JsonConvert.SerializeObject(deleteResult)}");

