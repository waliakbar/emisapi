FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["wwwapi/wwwapi.csproj", "wwwapi/"]
RUN dotnet restore "wwwapi/wwwapi.csproj"
COPY . .
WORKDIR "/src/wwwapi"
RUN dotnet build "wwwapi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "wwwapi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "wwwapi.dll"]