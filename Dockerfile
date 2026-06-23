# ==========================================
# 1. Etapa de Base: Entorno de ejecución (Runtime)
# ==========================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
# Exponemos el puerto estándar que usa .NET 8 por defecto
EXPOSE 8080
EXPOSE 8081

# ==========================================
# 2. Etapa de Construcción: Compilación del código
# ==========================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiamos el archivo de proyecto (.csproj) y restauramos las dependencias de NuGet
COPY ["LogisticMVP.csproj", "./"]
RUN dotnet restore "LogisticMVP.csproj"

# Copiamos absolutamente todo el resto del código del proyecto
COPY . .
WORKDIR "/src/."

# Compilamos la aplicación en modo Release para optimizar el rendimiento
RUN dotnet build "LogisticMVP.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ==========================================
# 3. Etapa de Publicación: Preparar los binarios limpios
# ==========================================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LogisticMVP.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ==========================================
# 4. Etapa Final: Imagen de producción ultra liviana
# ==========================================
FROM base AS final
WORKDIR /app
# Copiamos lo que se compiló limpiamente en la etapa anterior
COPY --from=publish /app/publish .

# Comando de entrada para arrancar nuestro monolito
ENTRYPOINT ["dotnet", "LogisticMVP.dll"]