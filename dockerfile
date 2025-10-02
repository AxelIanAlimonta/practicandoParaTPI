# Imagen base para construir la app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app

# Imagen base para ejecutar la app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

# Expone el puerto que usará la app (Render usará la variable PORT)
ENV ASPNETCORE_URLS=http://*:${PORT}
ENTRYPOINT ["dotnet", "practicandoParaTPI.dll"]
