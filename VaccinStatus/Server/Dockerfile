#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VaccinStatus/Server/VaccinStatus.Server.csproj", "VaccinStatus/Server/"]
COPY ["VaccinStatus/Client/VaccinStatus.Client.csproj", "VaccinStatus/Client/"]
COPY ["VaccinStatus/Shared/VaccinStatus.Shared.csproj", "VaccinStatus/Shared/"]
RUN dotnet restore "VaccinStatus/Server/VaccinStatus.Server.csproj"
COPY . .
WORKDIR "/src/VaccinStatus/Server"
RUN dotnet build "VaccinStatus.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VaccinStatus.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VaccinStatus.Server.dll"]