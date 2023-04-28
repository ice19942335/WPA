#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WPA.Api/WPA.Api.csproj", "WPA.Api/"]
RUN dotnet restore "WPA.Api/WPA.Api.csproj"
COPY . .
WORKDIR "/src/WPA.Api"
RUN dotnet build "WPA.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WPA.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WPA.Api.dll"]