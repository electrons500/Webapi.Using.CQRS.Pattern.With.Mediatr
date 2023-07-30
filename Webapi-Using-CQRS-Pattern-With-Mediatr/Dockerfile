#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Webapi-Using-CQRS-Pattern-With-Mediatr/Webapi-Using-CQRS-Pattern-With-Mediatr.csproj", "Webapi-Using-CQRS-Pattern-With-Mediatr/"]
RUN dotnet restore "Webapi-Using-CQRS-Pattern-With-Mediatr/Webapi-Using-CQRS-Pattern-With-Mediatr.csproj"
COPY . .
WORKDIR "/src/Webapi-Using-CQRS-Pattern-With-Mediatr"
RUN dotnet build "Webapi-Using-CQRS-Pattern-With-Mediatr.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Webapi-Using-CQRS-Pattern-With-Mediatr.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Webapi-Using-CQRS-Pattern-With-Mediatr.dll"]