namespace SimpleHttpClient.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddHttpClientService(this IServiceCollection services, string baseAddress)
    {
        services.AddHttpClient<ISimpleHttpClient, Services.SimpleHttpClient>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
    }
}