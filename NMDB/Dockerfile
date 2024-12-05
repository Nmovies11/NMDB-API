# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copy all project files into the container
COPY . .

# Debugging step to ensure NMDB.sln is copied
RUN ls -alh /source

# Restore dependencies for the solution with detailed logging
RUN dotnet restore "./NMDB.sln" -v detailed

# Publish all projects in one step (optional: add more specific restore for each project)
RUN dotnet publish "./NMDB-API/NMDB-API.csproj" -c Release -o /app --no-restore && \
    dotnet publish "./NMDB-BLL/NMDB-BLL.csproj" -c Release -o /app --no-restore && \
    dotnet publish "./NMDB-DAL/NMDB-DAL.csproj" -c Release -o /app --no-restore && \
    dotnet publish "./NMDB-Common/NMDB-Common.csproj" -c Release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS serve
WORKDIR /app

# Copy the build output from the build stage to the serve stage
COPY --from=build /app ./ 

# Expose the application port
EXPOSE 8080

# Set the entrypoint to the API DLL
ENTRYPOINT ["dotnet", "NMDB-API.dll"]