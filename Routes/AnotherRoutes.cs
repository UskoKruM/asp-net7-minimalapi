using System.Text.Json;

namespace MinimalAPI.Routes
{
    public static class AnotherRoutes
    {
        public static void Another(WebApplication app)
        {
            app.MapGet("/Ping", () => "Pong");

            app.MapPost("/CustomJSON", (dynamic json) =>
                {
                    Dictionary<string, string> dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

                    string value1 = dict["value1"];

                    return Results.Ok($"Value1: {value1}");
                }
            );
        }
    }
}
