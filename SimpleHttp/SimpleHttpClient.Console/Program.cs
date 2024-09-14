// See https://aka.ms/new-console-template for more information

ServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.AddSimpleHttpClient("https://evilinsult.com");
ServiceProvider services = serviceCollection.BuildServiceProvider();

ISimpleHttpClient simpleHttpClient = services.GetRequiredService<ISimpleHttpClient>();

InsultDto? result = await simpleHttpClient.GetAsync<InsultDto>("generate_insult.php?lang=fr&type=json");

Console.WriteLine($"{JsonConvert.SerializeObject(result)}");