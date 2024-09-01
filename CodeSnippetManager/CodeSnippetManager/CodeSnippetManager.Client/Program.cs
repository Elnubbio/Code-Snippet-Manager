using CodeSnippetManager.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient(Options.DefaultName, httpClient =>
{
	httpClient.BaseAddress = new Uri("http://localhost:5194/");
});
await builder.Build().RunAsync();
