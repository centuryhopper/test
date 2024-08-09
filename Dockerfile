FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Server/Server.csproj", "./"]
RUN dotnet restore "Server/Server.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Server/Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Server/Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test.dll"]
