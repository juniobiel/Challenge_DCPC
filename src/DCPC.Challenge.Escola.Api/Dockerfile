# Runtime (.NET 9)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Build + Publish (.NET 9 SDK)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia csproj e restaura
COPY DCPC.Challenge.Escola.Api/DCPC.Challenge.Escola.Api.csproj DCPC.Challenge.Escola.Api/
RUN dotnet restore DCPC.Challenge.Escola.Api/DCPC.Challenge.Escola.Api.csproj

# Copia o restante do código
COPY . .
# Publica o projeto
RUN dotnet publish DCPC.Challenge.Escola.Api/DCPC.Challenge.Escola.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

# Final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DCPC.Challenge.Escola.Api.dll"]

