# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /source

# Copy all project files into the container
COPY . .

# Restore dependencies for the solution (instead of individual projects)
RUN dotnet restore "./NMDB.sln"

# Publish all projects in one step
RUN dotnet publish "./NMDB-API/NMDB-API.csproj" -c Release -o /app --no-restore && \
    dotnet publish "./NMDB-BLL/NMDB-BLL.csproj" -c Release -o /app --no-restore && \
    dotnet publish "./NMDB-DAL/NMDB-DAL.csproj" -c Release -o /app --no-restore && \
    dotnet publish "./NMDB-Common/NMDB-Common.csproj" -c Release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS serve

# Set the working directory for the app
WORKDIR /app

# Copy the build output from the build stage to the serve stage
COPY --from=build /app ./ 

# Expose the application port
EXPOSE 8080

# Set the entrypoint to the API DLL
ENTRYPOINT ["dotnet", "NMDB-API.dll"]