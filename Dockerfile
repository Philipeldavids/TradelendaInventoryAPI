#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./TradelendaInventoryAPI/TradelendaInventoryAPI.csproj", "TradelendaInventoryAPI/"]
COPY ["./BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["./DataLayer/DataLayer.csproj", "DataLayer/"]
COPY ["./Infracstructure/Infracstructure.csproj", "Infracstructure/"]
RUN dotnet restore "./TradelendaInventoryAPI/TradelendaInventoryAPI.csproj"
COPY . .
WORKDIR "/src/TradelendaInventoryAPI"
RUN dotnet build "./TradelendaInventoryAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TradelendaInventoryAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TradelendaInventoryAPI.dll"]