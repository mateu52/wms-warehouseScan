# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Kopiujemy projekt i przywracamy pakiety
COPY wms-warehouseScan.csproj .
RUN dotnet restore

# Kopiujemy resztê plików i budujemy release
COPY . .
RUN dotnet publish -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

# Ustawienie portu, który Render u¿ywa
ENV ASPNETCORE_URLS=http://+:$PORT
EXPOSE $PORT

ENTRYPOINT ["dotnet", "wms-warehouseScan.dll"]
