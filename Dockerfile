# 1. IMAGEN DE CONSTRUCCIÓN (Equivalente a instalar extensiones y preparar el entorno)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiamos los archivos de proyecto (.csproj) y restauramos las dependencias
# Esto es como el "composer install" o el "apt-get install libpq-dev" del PHP
COPY *.csproj ./
RUN dotnet restore

# Copiamos el resto del código y compilamos la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# 2. IMAGEN FINAL (Equivalente al "php:8.2-apache" pero optimizado)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiamos lo que compilamos en la etapa anterior
COPY --from=build /app/out .

# Exponemos el puerto
EXPOSE 80

# El comando para arrancar la API
ENTRYPOINT ["dotnet", "handlyAdminScreens.dll"]