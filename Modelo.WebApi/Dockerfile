FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ../Modelo.WebApi/Modelo.WebApi.csproj ../Modelo.WebApi/
RUN dotnet restore ../Modelo.WebApi/Modelo.WebApi.csproj
COPY . .
WORKDIR /src/../Modelo.WebApi
RUN dotnet build Modelo.WebApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Modelo.WebApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Modelo.WebApi.dll"]
