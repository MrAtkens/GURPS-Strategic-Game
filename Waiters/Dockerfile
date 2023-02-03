#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DefaultTemplate.Api/DefaultTemplate.Api.csproj", "DefaultTemplate.Api/"]
COPY ["DefaultTemplate.DataAccess/DefaultTemplate.DataAccess.csproj", "DefaultTemplate.DataAccess/"]
COPY ["DefaultTemplate.Domain/DefaultTemplate.Domain.csproj", "DefaultTemplate.Domain/"]
COPY ["DefaultTemplate.Common/DefaultTemplate.Common.csproj", "DefaultTemplate.Common/"]
RUN dotnet restore "DefaultTemplate.Api/DefaultTemplate.Api.csproj"
COPY . .
WORKDIR "/src/DefaultTemplate.Api"
RUN dotnet build "DefaultTemplate.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DefaultTemplate.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DefaultTemplate.Api.dll"]
