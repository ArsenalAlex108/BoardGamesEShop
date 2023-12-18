# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set the working directory
WORKDIR /BoardGamesEShop

# Expose port 80 for the application.
EXPOSE 80

# Use the .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Copy the .sln file
COPY ["BoardGamesEShop.sln", "./"]

# Copy the .csproj files and restore the projects
COPY ["YourApp1/YourApp1.csproj", "YourApp1/"]
COPY ["YourApp2/YourApp2.csproj", "YourApp2/"]
RUN dotnet restore

# Copy all the files and build the app
COPY . .
WORKDIR "/src/YourApp1"
RUN dotnet build "YourApp1.csproj" -c Release -o /app/build

WORKDIR "/src/YourApp2"
RUN dotnet build "YourApp2.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
WORKDIR "/src/YourApp1"
RUN dotnet publish "YourApp1.csproj" -c Release -o /app/publish

WORKDIR "/src/YourApp2"
RUN dotnet publish "YourApp2.csproj" -c Release -o /app/publish

# Build the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YourApp1.dll"]