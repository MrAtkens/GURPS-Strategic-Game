#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MicroServices/Gateway/Gbim.Gateway/Gbim.Gateway.csproj", "MicroServices/Gateway/Gbim.Gateway/"]
COPY ["MicroServices/Shared/Gbim.Shared.Constant/Gbim.Shared.Constant.csproj", "MicroServices/Shared/Gbim.Shared.Constant/"]
COPY ["MicroServices/Shared/Gbim.Shared.DataContracts/Gbim.Shared.DataContracts.csproj", "MicroServices/Shared/Gbim.Shared.DataContracts/"]
COPY ["MicroServices/Shared/Gbim.Shared.Http/Gbim.Shared.Http.csproj", "MicroServices/Shared/Gbim.Shared.Http/"]
RUN dotnet restore "MicroServices/Gateway/Gbim.Gateway/Gbim.Gateway.csproj"
COPY . .
WORKDIR "/src/MicroServices/Gateway/Gbim.Gateway"
RUN dotnet build "Gbim.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gbim.Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gbim.Gateway.dll"]
