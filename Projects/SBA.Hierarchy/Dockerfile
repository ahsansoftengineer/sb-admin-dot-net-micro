# ===========================================================
# Build:
# docker build -t mansanhhub/srvc-hierarchy -f Projects/SBA.Hierarchy/Dockerfile .
# docker push mansanhhub/srvc-hierarchy
# docker run -d --name srvc-hierarchy -p 1106:1106 -e DOTNET_ENVIRONMENT=Docker mansanhhub/srvc-hierarchy
# docker rm -f srvc-hierarchy
# docker exec -it <container_id> /bin/bash

# http://localhost:1106/api/hierarchy/v1/swagger/index.html
# http://localhost:1106/api/hierarchy/v1/_projectz-lookup/gets-lookup

# Stage 1: Build
FROM local/sdk:9.0 AS sdk
WORKDIR /app

# Copy only .csproj files first (to enable Docker caching of restore)
# COPY GLOB/GLOB.API.Config/*.csproj ./GLOB/GLOB.API.Config/
# COPY GLOB/GLOB.Infra/*.csproj ./GLOB/GLOB.Infra/
# COPY GLOB/GLOB.API/*.csproj ./GLOB/GLOB.API/

COPY GLOB/GLOB.Domain/*.csproj ./GLOB/GLOB.Domain/
COPY Projects/SBA.Hierarchy/*.csproj ./Projects/SBA.Hierarchy/

COPY Published/nuget.config ./GLOB/GLOB.Domain/
COPY Published/nuget.config ./Projects/SBA.Hierarchy/
COPY Published/GLOB.*.nupkg ./Published/

# Restore dependencies
RUN --mount=type=cache,target=/root/.nuget/packages,sharing=locked,id=nuget-cache \
    dotnet restore ./Projects/SBA.Hierarchy/SBA.Hierarchy.csproj \
        --property:UseNuget=true \
        --configfile ./Projects/SBA.Hierarchy/nuget.config \
        --verbosity detailed

# Copy the rest of the source files
# COPY GLOB/GLOB.API.Config/ ./GLOB/GLOB.API.Config/
# COPY GLOB/GLOB.Infra/ ./GLOB/GLOB.Infra/
# COPY GLOB/GLOB.API/ ./GLOB/GLOB.API/

COPY GLOB/GLOB.Domain/ ./GLOB/GLOB.Domain/
COPY Projects/SBA.Hierarchy/ ./Projects/SBA.Hierarchy/

# Build and publish
WORKDIR /app/Projects/SBA.Hierarchy
RUN --mount=type=cache,target=/root/.nuget/packages,sharing=locked,id=nuget-cache \
    dotnet publish SBA.Hierarchy.csproj -c Release -o /app/out \
        --property:UseNuget=true \
        --no-restore

# Stage 2: Runtime
FROM local/runtime:9.0
WORKDIR /app/Projects/SBA.Hierarchy

# Copy the published app from build stage
COPY --from=sdk /app/out .

# Runtime environment variables (can be overridden at runtime via CLI, Docker Compose, etc.)
ENV ASPNETCORE_URLS=http://+:1106
ENV DOTNET_ENVIRONMENT=Docker
ENV ConnectionStrings__SqlConnection="Server=host.docker.internal,1433;Initial Catalog=SBA_Hierarchy;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;"

EXPOSE 1106

ENTRYPOINT [ "dotnet", "SBA.Hierarchy.dll" ]