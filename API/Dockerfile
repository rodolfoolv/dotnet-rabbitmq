# Etapa de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./API/*.csproj ./API/
RUN dotnet restore ./API/API.csproj
COPY . ./
RUN dotnet publish ./API/API.csproj -c Release -o /app

# Etapa de Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "API.dll"]
