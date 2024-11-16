#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Asd.Hrm.Web.Host/Asd.Hrm.Web.Host.csproj", "src/Asd.Hrm.Web.Host/"]
COPY ["src/Asd.Hrm.Web.Core/Asd.Hrm.Web.Core.csproj", "src/Asd.Hrm.Web.Core/"]
COPY ["src/Asd.Hrm.Application/Asd.Hrm.Application.csproj", "src/Asd.Hrm.Application/"]
COPY ["src/Asd.Hrm.Application.Shared/Asd.Hrm.Application.Shared.csproj", "src/Asd.Hrm.Application.Shared/"]
COPY ["src/Asd.Hrm.Core.Shared/Asd.Hrm.Core.Shared.csproj", "src/Asd.Hrm.Core.Shared/"]
COPY ["src/Asd.Hrm.Core/Asd.Hrm.Core.csproj", "src/Asd.Hrm.Core/"]
COPY ["src/Asd.Hrm.EntityFrameworkCore/Asd.Hrm.EntityFrameworkCore.csproj", "src/Asd.Hrm.EntityFrameworkCore/"]
COPY ["src/Asd.Hrm.GraphQL/Asd.Hrm.GraphQL.csproj", "src/Asd.Hrm.GraphQL/"]
RUN dotnet restore "src/Asd.Hrm.Web.Host/Asd.Hrm.Web.Host.csproj"
COPY . .
WORKDIR "/src/src/Asd.Hrm.Web.Host"
RUN dotnet build "Asd.Hrm.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Asd.Hrm.Web.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Asd.Hrm.Web.Host.dll"]
