#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/JacarandaCasaDeBrincar.Api/JacarandaCasaDeBrincar.Api.csproj", "src/JacarandaCasaDeBrincar.Api/"]
COPY ["src/JacarandaCasaDeBrincar.Data/JacarandaCasaDeBrincar.Data.csproj", "src/JacarandaCasaDeBrincar.Data/"]
COPY ["src/JacarandaCasaDeBrincar.Business/JacarandaCasaDeBrincar.Business.csproj", "src/JacarandaCasaDeBrincar.Business/"]
RUN dotnet restore "src/JacarandaCasaDeBrincar.Api/JacarandaCasaDeBrincar.Api.csproj"
COPY . .
WORKDIR "/src/src/JacarandaCasaDeBrincar.Api"
RUN dotnet build "JacarandaCasaDeBrincar.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JacarandaCasaDeBrincar.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JacarandaCasaDeBrincar.Api.dll"]