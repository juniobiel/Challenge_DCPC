FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443

#ENV ASPNETCORE_URLS=http://+:8000;http://+:80;

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Copy all in this root folder
COPY ./InvesTrace.Identity.Api/InvesTrace.Identity.Api.csproj /InvesTrace.Identity.Api/
WORKDIR /InvesTrace.Identity.Api
# Restore libraries
RUN dotnet restore

COPY . .

RUN dotnet build InvesTrace.Identity.Api/InvesTrace.Identity.Api.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish InvesTrace.Identity.Api/InvesTrace.Identity.Api.csproj -c Release -o /app/publish

FROM runtime AS final
WORKDIR /app
COPY --from=publish /app/publish .

ARG ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT $ENVIRONMENT
ENTRYPOINT [ "dotnet", "InvesTrace.Identity.Api.dll" ]

# Usa porta dinâmica do Heroku
#CMD ASPNETCORE_URLS="http://*:$PORT" dotnet InvesTrace.Identity.Api.dll

