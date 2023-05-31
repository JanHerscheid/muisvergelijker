FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set working directory
WORKDIR /src

# Alle csproj files kopieren
COPY muisvergelijker/*.csproj ./muisvergelijker/
COPY DAL/*.csproj ./DAL/
COPY DTO/*.csproj ./DTO/
COPY Logic/*.csproj ./Logic/

# list alle directories voor het debuggen
RUN pwd && ls

# Copy all files
COPY . .

WORKDIR /src/muisvergelijker
RUN dotnet restore -v d
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /src/muisvergelijker/out .
ENTRYPOINT ["dotnet", "muisvergelijker.dll"]