# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copy all project files into the container
COPY . .


# Restore dependencies for the solution with detailed logging
RUN dotnet restore "./NMDB-API/NMDB-API.csproj"
RUN dotnet publish "./NMDB-API/NMDB-API.csproj" -c release -o /app --no-restore
RUN dotnet restore "./NMDB-BLL/NMDB-BLL.csproj"
RUN dotnet publish "./NMDB-BLL/NMDB-BLL.csproj" -c release -o /app --no-restore
RUN dotnet restore "./NMDB-DAL/NMDB-DAL.csproj"
RUN dotnet publish "./NMDB-DAL/NMDB-DAL.csproj" -c release -o /app --no-restore
RUN dotnet restore "./NMDB-Common/NMDB-Common.csproj"
RUN dotnet publish "./NMDB-Common/NMDB-Common.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS serve
WORKDIR /app

# Copy the build output from the build stage to the serve stage
COPY --from=build /app ./ 

EXPOSE 8080

# Set the entrypoint to the API DLL
ENTRYPOINT ["dotnet", "NMDB-API.dll"]