#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ArklensApiFaker.csproj", "."]
RUN dotnet restore "./ArklensApiFaker.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ArklensApiFaker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArklensApiFaker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY Map.png Map.png
ENTRYPOINT ["dotnet", "ArklensApiFaker.dll"]