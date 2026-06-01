FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /build_dir

# 1. Copiar solo los archivos .csproj para restaurar
COPY ["src/Presentation/Polyglots.Presentation.WebAPI/Polyglots.Presentation.WebAPI.csproj", "src/Presentation/Polyglots.Presentation.WebAPI/"]
COPY ["src/Infrastructure/Polyglots.Infrastructure.Persistence/Polyglots.Infrastructure.Persistence.csproj", "src/Infrastructure/Polyglots.Infrastructure.Persistence/"]
COPY ["src/Application/Polyglots.Application/Polyglots.Application.csproj", "src/Application/Polyglots.Application/"]
COPY ["src/Domain/Polyglots.Domain/Polyglots.Domain.csproj", "src/Domain/Polyglots.Domain/"]
COPY ["src/Shared/Polyglots.ServiceDefaults/Polyglots.ServiceDefaults.csproj", "src/Shared/Polyglots.ServiceDefaults/"]

RUN dotnet restore "src/Presentation/Polyglots.Presentation.WebAPI/Polyglots.Presentation.WebAPI.csproj"

# 2. Copiar el código fuente de los proyectos necesarios
COPY ["src/Presentation/Polyglots.Presentation.WebAPI/", "src/Presentation/Polyglots.Presentation.WebAPI/"]
COPY ["src/Infrastructure/Polyglots.Infrastructure.Persistence/", "src/Infrastructure/Polyglots.Infrastructure.Persistence/"]
COPY ["src/Application/Polyglots.Application/", "src/Application/Polyglots.Application/"]
COPY ["src/Domain/Polyglots.Domain/", "src/Domain/Polyglots.Domain/"]
COPY ["src/Shared/Polyglots.ServiceDefaults/", "src/Shared/Polyglots.ServiceDefaults/"]

WORKDIR "/build_dir/src/Presentation/Polyglots.Presentation.WebAPI"

# 3. Publicar directamente
FROM build AS publish
RUN dotnet publish "./Polyglots.Presentation.WebAPI.csproj" -c Release --property:PublishDir=/app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Polyglots.Presentation.WebAPI.dll"]