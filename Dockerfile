# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files
COPY BankAPI.sln .
COPY BankAPI/BankAPI.csproj BankAPI/
COPY BankAPI.Tests/BankAPI.Tests.csproj BankAPI.Tests/

# Restore NuGet packages
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Publish the API
RUN dotnet publish BankAPI/BankAPI.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy published application
COPY --from=build /app/publish .

EXPOSE 8080

# Start the application
ENTRYPOINT ["dotnet", "BankAPI.dll"]