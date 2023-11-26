using EntryPoint.WebApi;

var app = WebApplication
    .CreateBuilder(args)
    .Configure()
    .Build()
    .Configure();

await app.ExecuteAsync();