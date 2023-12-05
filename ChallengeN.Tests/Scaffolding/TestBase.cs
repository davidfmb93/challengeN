using ChallengeN.Infrastructure.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace ChallengeN.Tests.Scaffolding;

public abstract class TestBase : WebApplicationTestFactory<Program>
{
    private CNDbContext? _dbContext;
    private HttpClient? _httpClient;

    private const string Patch = "Patch";
    private const string Put = "Put";

    protected CNDbContext DbContext
    {
        get
        {
            if (_dbContext is null)
            {
                var scope = Services.CreateScope();
                _dbContext = scope.ServiceProvider.GetService<CNDbContext>()!;
                _dbContext.Database.EnsureDeleted();
            }

            return _dbContext;
        }
    }

    protected HttpClient HttpClient => _httpClient ??= CreateClient();

    protected async Task<TResponse> SendRequestAsync<TResponse>(string method, object data, string url) where TResponse : class
    {
        HttpMethod httpMethod = HttpMethod.Post;

        switch (method)
        {
            case Put:
                httpMethod = HttpMethod.Put;
                break;
            case Patch:
                httpMethod = HttpMethod.Patch;
                break;
        }

        var request = new HttpRequestMessage(httpMethod, url);

        if (httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Put || httpMethod == HttpMethod.Patch)
        {
            request.Content = JsonContent.Create(data);
        }

        var response = await HttpClient.SendAsync(request);

        var responseContent = await response.Content.ReadFromJsonAsync<TResponse>();

        responseContent.ShouldNotBeNull();

        return responseContent;
    }
}
