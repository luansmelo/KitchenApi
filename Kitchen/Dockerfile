#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Kitchen/Kitchen.API.csproj", "Kitchen/"]
COPY ["Kitchen.Application/Kitchen.Application.csproj", "Kitchen.Application/"]
COPY ["Kitchen.Domain/Kitchen.Domain.csproj", "Kitchen.Domain/"]
COPY ["Kitchen.Infra/Kitchen.Infra.csproj", "Kitchen.Infra/"]
RUN dotnet restore "./Kitchen/Kitchen.API.csproj"
COPY . .
WORKDIR "/src/Kitchen"
RUN dotnet build "./Kitchen.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Kitchen.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kitchen.API.dll"]