#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MicroServiceContainer/MicroServiceContainer.csproj", "MicroServiceContainer/"]
COPY ["Dominio.Aplicacion/Dominio.Aplicacion.csproj", "Dominio.Aplicacion/"]
COPY ["Dominio.Infraestructura/Dominio.Infraestructura.csproj", "Dominio.Infraestructura/"]
COPY ["Dominio.Model/Dominio.Model.csproj", "Dominio.Model/"]
RUN dotnet restore "MicroServiceContainer/MicroServiceContainer.csproj"
COPY . .
WORKDIR "/src/MicroServiceContainer"
RUN dotnet build "MicroServiceContainer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroServiceContainer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroServiceContainer.dll"]
