namespace APICancelaFaturamento.Middleware;

public class ApiKeyMiddleware
{
    private const string ApiKeyHeaderName = "x-api-key";
    private const string ApiKeyValue = "APICANCELA-FATURAMENTO-TESTE";
    private readonly RequestDelegate _next;

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/swagger") || context.Request.Path.StartsWithSegments("/health"))
        {
            await _next(context);
            return;
        }

        if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKey) ||
            string.IsNullOrWhiteSpace(apiKey) ||
            !string.Equals(apiKey.ToString(), ApiKeyValue, StringComparison.Ordinal))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new
            {
                erro = "API Key inválida ou não informada.",
                mensagem = "Informe o header x-api-key com a chave correta."
            });
            return;
        }

        await _next(context);
    }
}
