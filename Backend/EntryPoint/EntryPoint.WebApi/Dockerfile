FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Backend/EntryPoint/EntryPoint.WebApi/EntryPoint.WebApi.csproj", "Backend/EntryPoint/EntryPoint.WebApi/"]
RUN dotnet restore "Backend/EntryPoint/EntryPoint.WebApi/EntryPoint.WebApi.csproj"
COPY . .
WORKDIR "/src/Backend/EntryPoint/EntryPoint.WebApi"
RUN dotnet build "EntryPoint.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EntryPoint.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EntryPoint.WebApi.dll"]
