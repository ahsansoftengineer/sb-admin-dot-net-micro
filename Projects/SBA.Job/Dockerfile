# ===========================================================
# Build:
# docker build -t mansanhhub/srvc-job -f Projects/SBA.Job/Dockerfile .
# docker push mansanhhub/srvc-job
# docker run -d --name srvc-job -p 1102:1102 -e DOTNET_ENVIRONMENT=Docker mansanhhub/srvc-job
# docker rm -f srvc-job
# docker exec -it <container_id> /bin/bash

# http://localhost:1102/api/job/v1/swagger/index.html
# http://localhost:1102/api/job/v1/_projectz-lookup/gets-lookup
# Stage 1: Build
FROM local/sdk:9.0 AS sdk
WORKDIR /app

# Copy only .csproj files first (to enable Docker caching of restore)
# COPY GLOB/GLOB.API.Config/*.csproj ./GLOB/GLOB.API.Config/
# COPY GLOB/GLOB.Infra/*.csproj ./GLOB/GLOB.Infra/
# COPY GLOB/GLOB.API/*.csproj ./GLOB/GLOB.API/

COPY GLOB/GLOB.Domain/*.csproj ./GLOB/GLOB.Domain/
COPY Projects/SBA.Job/*.csproj ./Projects/SBA.Job/

COPY Published/nuget.config ./GLOB/GLOB.Domain/
COPY Published/nuget.config ./Projects/SBA.Job/
COPY Published/GLOB.*.nupkg ./Published/

# Restore dependencies
RUN --mount=type=cache,target=/root/.nuget/packages,sharing=locked,id=nuget-cache \
    dotnet restore ./Projects/SBA.Job/SBA.Job.csproj \
        --property:UseNuget=true \
        --configfile ./Projects/SBA.Job/nuget.config \
        --verbosity detailed

# Copy the rest of the source files
# COPY GLOB/GLOB.API.Config/ ./GLOB/GLOB.API.Config/
# COPY GLOB/GLOB.Infra/ ./GLOB/GLOB.Infra/
# COPY GLOB/GLOB.API/ ./GLOB/GLOB.API/

COPY GLOB/GLOB.Domain/ ./GLOB/GLOB.Domain/
COPY Projects/SBA.Job/ ./Projects/SBA.Job/

# Build and publish
WORKDIR /app/Projects/SBA.Job
RUN --mount=type=cache,target=/root/.nuget/packages,sharing=locked,id=nuget-cache \
    dotnet publish SBA.Job.csproj -c Release -o /app/out \
        --property:UseNuget=true \
        --no-restore

# Stage 2: Runtime
FROM local/runtime:9.0
WORKDIR /app/Projects/SBA.Job

# Copy the published app from build stage
COPY --from=build-env /app/out .

# Runtime environment variables (can be overridden at runtime via CLI, Docker Compose, etc.)
ENV ASPNETCORE_URLS=http://+:1102
ENV DOTNET_ENVIRONMENT=Docker
ENV ConnectionStrings__SqlConnection="Server=host.docker.internal,1433;Initial Catalog=SBA_Job;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;"

EXPOSE 1102

ENTRYPOINT [ "dotnet", "SBA.Job.dll" ]