# Usa una imagen base que tenga soporte para .NET
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Establece el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copia el archivo csproj y restaura dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia todo el resto del código y compila la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Define el contenedor de destino
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "FacturacionSriApi.dll"]
