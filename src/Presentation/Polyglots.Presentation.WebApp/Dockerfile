FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /build_dir

# 1. Copiar solo los .csproj necesarios para la restauración de paquetes
COPY ["src/Presentation/Polyglots.Presentation.WebApp/Polyglots.Presentation.WebApp.csproj", "src/Presentation/Polyglots.Presentation.WebApp/"]
COPY ["src/Shared/Polyglots.Shared/Polyglots.Shared.csproj", "src/Shared/Polyglots.Shared/"]

RUN dotnet restore "src/Presentation/Polyglots.Presentation.WebApp/Polyglots.Presentation.WebApp.csproj"

# 2. Copiar el código fuente requerido
COPY ["src/Presentation/Polyglots.Presentation.WebApp/", "src/Presentation/Polyglots.Presentation.WebApp/"]
COPY ["src/Shared/Polyglots.Shared/", "src/Shared/Polyglots.Shared/"]

WORKDIR "/build_dir/src/Presentation/Polyglots.Presentation.WebApp"

# 3. Compilar la aplicación en modo Release para web estática
FROM build AS publish
RUN dotnet workload install wasm-tools
RUN dotnet publish "./Polyglots.Presentation.WebApp.csproj" -c Release --property:PublishDir=/app/publish

# 4. Fase final: Usar Nginx para servir el contenido estático
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

COPY --from=publish /app/publish/wwwroot .
COPY src/Presentation/Polyglots.Presentation.WebApp/nginx.webapp.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]