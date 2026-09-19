using APICancelaFaturamento.Middleware;
using APICancelaFaturamento.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<JsonExampleService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.Run();
