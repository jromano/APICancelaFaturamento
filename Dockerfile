# Etapa de compilação
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src


RUN dotnet restore "APICancelaFaturamento.csproj"

RUN dotnet publish "APICancelaFaturamento.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore


# Etapa de execução
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "APICancelaFaturamento.dll"]