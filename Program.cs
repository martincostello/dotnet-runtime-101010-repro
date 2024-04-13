using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddTransient<ReleaseNotesService>();
    
services.AddHttpClient();

// Comment out the line below and no exception will be thrown
services.AddHttpClient<ReleaseNotesService>((provider, client) =>{ /* No-op */});

using var serviceProvider = services.BuildServiceProvider();

var service = serviceProvider.GetRequiredService<ReleaseNotesService>();
using var releaseNotes = await service.GetReleasesIndexAsync();

var latest = releaseNotes?.RootElement
    .GetProperty("releases-index")
    .EnumerateArray()
    .First()
    .GetProperty("latest-release")
    .GetString();

Console.WriteLine($"The latest release of .NET 9 is {latest}");

sealed class ReleaseNotesService(HttpClient httpClient)
{
    public async Task<JsonDocument?> GetReleasesIndexAsync() =>
        await httpClient.GetFromJsonAsync(
            "https://raw.githubusercontent.com/dotnet/core/main/release-notes/releases-index.json",
            AppJsonSerializerContext.Default.JsonDocument);
}

[JsonSerializable(typeof(JsonDocument))]
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
sealed partial class AppJsonSerializerContext : JsonSerializerContext;
