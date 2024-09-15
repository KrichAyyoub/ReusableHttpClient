namespace StupidHttpClient.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddStupidHttpClient(this IServiceCollection services, string baseAddress)
    {
        services.AddHttpClient<IStupidHttpClient, Services.StupidHttpClient>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
    }
}