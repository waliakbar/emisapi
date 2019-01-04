FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./wwwapi/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ./wwwapi/ ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "wwwapi.dll"]

EXPOSE 5000

#Install-package Newtonsoft.Json

#	docker build -t wwwapi .
#	docker run -it -p 5000:80 wwwapi