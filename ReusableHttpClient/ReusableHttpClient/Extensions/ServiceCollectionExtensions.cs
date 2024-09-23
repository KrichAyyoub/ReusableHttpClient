namespace ReusableHttpClient.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddReusableHttpClient(this IServiceCollection services, string baseAddress)
    {
        services.AddHttpClient<IReusableHttpClient, Services.ReusableHttpClient>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
    }
}