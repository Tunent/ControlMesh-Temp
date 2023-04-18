#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ControlMesh.Host/ControlMesh.Host.csproj", "ControlMesh.Host/"]
COPY ["ControlMesh.Database/ControlMesh.Database.csproj", "ControlMesh.Database/"]
COPY ["ControlMesh.Repository/ControlMesh.Repository.csproj", "ControlMesh.Repository/"]
RUN dotnet restore "ControlMesh.Host/ControlMesh.Host.csproj"
COPY . .
WORKDIR "/src/ControlMesh.Host"
RUN dotnet build "ControlMesh.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ControlMesh.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ARG dbconnstr
ENV env_dbconnstr ""
ARG sbconnstr
ENV env_sbconnstr ""
ARG instrumentationkey
ENV instrumentationkey ""

ENTRYPOINT ["dotnet", "ControlMesh.Host.dll"]