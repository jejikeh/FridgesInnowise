using EntryPoint.WebApi;

var app = WebApplication
    .CreateBuilder(args)
    .ConfigureBuilder()
    .Build()
    .ConfigureApplication();

await app.ExecuteAsync();