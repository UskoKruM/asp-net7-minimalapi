/*
WebApplicationBuilder builder = WebApplication.CreateBuilder(args)
WebApplication app = builder.Build()
*/

using MinimalAPI.Models;
using MinimalAPI.Routes;

WebApplication app = WebApplication.Create(args);

app.Logger.LogWarning("Test Message");

app.MapGet("/", () => "Hello World! 123");

app.MapGet("/GetName", () => app.Configuration["Data:Name"]);

app.MapGet("/SayHi/{name}", (string name) => $"Hello, {name}!");

app.MapPost("/AddProgrammer", (Programmer programmer) =>
    {
        programmer.Id = Guid.NewGuid().ToString();

        app.Logger.LogInformation($"{programmer.Id}: {programmer.Name}");

        return Results.StatusCode(200);
    }
);

AnotherRoutes.Another(app);

app.Run(app.Configuration["Data:Url"]);
