#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5101

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Waiters.Api/Waiters.Api.csproj", "Waiters.Api/"]
COPY ["Waiters.DataAccess/Waiters.DataAccess.csproj", "Waiters.DataAccess/"]
COPY ["Waiters.Domain/Waiters.Domain.csproj", "Waiters.Domain/"]
COPY ["Waiters.Common/Waiters.Common.csproj", "Waiters.Common/"]
RUN dotnet restore "Waiters.Api/Waiters.Api.csproj"
COPY . .
WORKDIR "/src/Waiters.Api"
RUN dotnet build "Waiters.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Waiters.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Waiters.Api.dll"]
