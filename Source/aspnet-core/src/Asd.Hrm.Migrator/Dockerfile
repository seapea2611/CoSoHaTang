#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Asd.Hrm.Migrator/Asd.Hrm.Migrator.csproj", "src/Asd.Hrm.Migrator/"]
COPY ["src/Asd.Hrm.EntityFrameworkCore/Asd.Hrm.EntityFrameworkCore.csproj", "src/Asd.Hrm.EntityFrameworkCore/"]
COPY ["src/Asd.Hrm.Core/Asd.Hrm.Core.csproj", "src/Asd.Hrm.Core/"]
COPY ["src/Asd.Hrm.Core.Shared/Asd.Hrm.Core.Shared.csproj", "src/Asd.Hrm.Core.Shared/"]
RUN dotnet restore "src/Asd.Hrm.Migrator/Asd.Hrm.Migrator.csproj"
COPY . .
WORKDIR "/src/src/Asd.Hrm.Migrator"
RUN dotnet build "Asd.Hrm.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Asd.Hrm.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Asd.Hrm.Migrator.dll"]
