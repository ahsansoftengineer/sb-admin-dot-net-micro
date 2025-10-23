# Build:
# docker build -t mansanhhub/srvc-gateway -f Projects/SBA.APIGateway/Dockerfile .
# docker push mansanhhub/srvc-gateway
# docker run -d --name srvc-gateway -p 1100:1100 -e DOTNET_ENVIRONMENT=Docker mansanhhub/srvc-gateway
# docker rm -f srvc-gateway
# docker exec -it <container_id> /bin/bash

# http://localhost:1100/api/gateway/v1/swagger/index.html
# http://localhost:1100/api/gateway/v1/_projectz-lookup/gets-lookup

# ===========================================================

# Stage 1: Build
FROM local/sdk:9.0 AS sdk
WORKDIR /app

# Copy only .csproj files first (to enable Docker caching of restore)
# COPY GLOB/GLOB.API.Config/*.csproj ./GLOB/GLOB.API.Config/
COPY Projects/SBA.APIGateway/*.csproj ./Projects/SBA.APIGateway/

COPY Published/nuget.config ./Projects/SBA.APIGateway/
COPY Published/GLOB.*.nupkg ./Published/

# Restore dependencies
RUN --mount=type=cache,target=/root/.nuget/packages,sharing=locked,id=nuget-cache \
    dotnet restore ./Projects/SBA.APIGateway/SBA.APIGateway.csproj \
        --property:UseNuget=true \
        --configfile ./Projects/SBA.APIGateway/nuget.config \
        --verbosity detailed

# Copy the rest of the source files
# COPY GLOB/GLOB.API.Config/ ./GLOB/GLOB.API.Config/
COPY Projects/SBA.APIGateway/ ./Projects/SBA.APIGateway/

# Build and publish
WORKDIR /app/Projects/SBA.APIGateway
RUN --mount=type=cache,target=/root/.nuget/packages,sharing=locked,id=nuget-cache \
    dotnet publish SBA.APIGateway.csproj -c Release -o /app/out \
        --property:UseNuget=true \
        --no-restore

# Stage 2: Runtime
FROM local/runtime:9.0
WORKDIR /app/Projects/SBA.APIGateway

# Copy the published app from build stage
COPY --from=sdk /app/out .

# Runtime environment variables (can be overridden at runtime via CLI, Docker Compose, etc.)
ENV DOTNET_ENVIRONMENT=Docker

EXPOSE 1100

ENTRYPOINT [ "dotnet", "SBA.APIGateway.dll" ]
