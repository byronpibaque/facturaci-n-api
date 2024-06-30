# Dockerfile en la raíz de la solución

# Etapa de construcción
# Utiliza el SDK de .NET para construir los proyectos
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia y restaura los archivos de proyecto para cada proyecto
COPY FacturacionSriApi/FacturacionSriApi.csproj FacturacionSriApi/
COPY SriWebService/SriWebService.csproj SriWebService/

# Restaura las dependencias
RUN dotnet restore FacturacionSriApi/FacturacionSriApi.csproj
RUN dotnet restore SriWebService/SriWebService.csproj

# Copia el resto del código y construye la solución
COPY . .
WORKDIR /app/FacturacionSriApi
RUN dotnet build -c Release -o /app/build

WORKDIR /app/SriWebService
RUN dotnet build -c Release -o /app/build

# Etapa de publicación
# Publica cada proyecto
FROM build AS publish
WORKDIR /app/FacturacionSriApi
RUN dotnet publish -c Release -o /app/publish

WORKDIR /app/SriWebService
RUN dotnet publish -c Release -o /app/publish

# Etapa final
# Utiliza la imagen base ASP.NET para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Define el comando de inicio de la aplicación
ENTRYPOINT ["dotnet", "FacturacionSriApi.dll"]
