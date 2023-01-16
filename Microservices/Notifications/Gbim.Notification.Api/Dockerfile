#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MicroServices/Notifications/Gbim.Notification.Api/Gbim.Notification.Api.csproj", "MicroServices/Notifications/Gbim.Notification.Api/"]
COPY ["MicroServices/NcaNode/NCANodeApi.Client/NCANodeApi.Client.csproj", "MicroServices/NcaNode/NCANodeApi.Client/"]
COPY ["MicroServices/Notifications/Gbim.Notification.Client/Gbim.Notification.Client.csproj", "MicroServices/Notifications/Gbim.Notification.Client/"]
COPY ["MicroServices/Shared/Gbim.Shared.Constant/Gbim.Shared.Constant.csproj", "MicroServices/Shared/Gbim.Shared.Constant/"]
COPY ["MicroServices/Shared/Gbim.Shared.Http/Gbim.Shared.Http.csproj", "MicroServices/Shared/Gbim.Shared.Http/"]
COPY ["MicroServices/Shared/Gbim.Shared.DataContracts/Gbim.Shared.DataContracts.csproj", "MicroServices/Shared/Gbim.Shared.DataContracts/"]
RUN dotnet restore "MicroServices/Notifications/Gbim.Notification.Api/Gbim.Notification.Api.csproj"
COPY . .
WORKDIR "/src/MicroServices/Notifications/Gbim.Notification.Api"
RUN dotnet build "Gbim.Notification.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gbim.Notification.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gbim.Notification.Api.dll"]
