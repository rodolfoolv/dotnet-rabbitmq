# Etapa de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./Consumer.Console/*.csproj ./Consumer.Console/
RUN dotnet restore ./Consumer.Console/Consumer.Console.csproj
COPY . ./
RUN dotnet publish ./Consumer.Console/Consumer.Console.csproj -c Release -o /app

# Etapa de Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Consumer.Console.dll"]
