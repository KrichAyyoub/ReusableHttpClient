// See https://aka.ms/new-console-template for more information

ServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.AddStupidHttpClient("https://evilinsult.com");
ServiceProvider services = serviceCollection.BuildServiceProvider();

IStupidHttpClient stupidHttpClient = services.GetRequiredService<IStupidHttpClient>();

InsultDto? result = await stupidHttpClient.GetAsync<InsultDto>("generate_insult.php?lang=fr&type=json");

Console.WriteLine($"{JsonConvert.SerializeObject(result)}");