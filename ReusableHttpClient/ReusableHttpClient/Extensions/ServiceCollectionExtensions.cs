namespace ReusableHttpClient.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddReusableHttpClient(this IServiceCollection services, string name, string baseAddress)
    {
        services.AddHttpClient();

        services.AddHttpClient<IReusableHttpClient, Services.ReusableHttpClient>(name,
            client => { client.BaseAddress = new Uri(baseAddress); });
    }
}