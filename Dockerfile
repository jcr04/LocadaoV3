#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LocadaoV3.API/LocadaoV3.API.csproj", "LocadaoV3.API/"]
COPY ["LocadaoV3.Application/LocadaoV3.Application.csproj", "LocadaoV3.Application/"]
COPY ["LocadaoV3.Domain/LocadaoV3.Domain.csproj", "LocadaoV3.Domain/"]
COPY ["LocadaoV3.Infra/LocadaoV3.Infra.csproj", "LocadaoV3.Infra/"]
RUN dotnet restore "./LocadaoV3.API/LocadaoV3.API.csproj"
COPY . .
WORKDIR "/src/LocadaoV3.API"
RUN dotnet build "./LocadaoV3.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LocadaoV3.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocadaoV3.API.dll"]