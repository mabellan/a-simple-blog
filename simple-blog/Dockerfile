# Usa una imagen base de .NET Core 7.0
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Crea un directorio de trabajo en la imagen
WORKDIR /app

# Copia el archivo de proyecto y restaura las dependencias
COPY simple-blog.csproj ./
RUN dotnet restore

# Copia el resto de los archivos de la aplicación
COPY . ./

# Construye la aplicación
RUN dotnet publish -c Release -o out

# Usa una imagen base de .NET Core 7.1 más pequeña
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Crea un directorio de trabajo en la imagen
WORKDIR /app

# Copia la aplicación compilada desde la imagen anterior
COPY --from=build-env /app/out .

# Especifica el comando que se ejecutará cuando se inicie el contenedor
CMD ["dotnet", "simple-blog.dll"]
