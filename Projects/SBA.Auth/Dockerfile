# ===========================================================
# Build:
# docker build -t mansanhhub/srvc-auth -f Projects/SBA.Auth/Dockerfile .
# docker push mansanhhub/srvc-auth
# docker pull mansanhhub/srvc-auth
# docker rm -f srvc-auth
# docker run -d --name srvc-auth --network sba-dev-network -p 1104:1104 -p 1105:1105 -v //c/D/net-micro/dev-cert.pfx:/app/dev-cert.pfx:ro -v //c/D/net-micro/dev-root-cert.crt:/app/dev-root-cert.crt:ro mansanhhub/srvc-auth
# docker exec -it <container_id> /bin/bash

# http://localhost:1104/api/auth/v1/swagger/index.html
# http://localhost:1104/api/auth/v1/_projectz-lookup/gets-lookup
# Stage 1: Build
FROM local/sdk:9.0 AS sdk
WORKDIR /app

# Copy only .csproj files first (to enable Docker caching of restore)
# COPY GLOB/GLOB.API.Config/*.csproj ./GLOB/GLOB.API.Config/
# COPY GLOB/GLOB.Infra/*.csproj ./GLOB/GLOB.Infra/
# COPY GLOB/GLOB.API/*.csproj ./GLOB/GLOB.API/

COPY GLOB/GLOB.Domain/*.csproj ./GLOB/GLOB.Domain/
COPY Projects/SBA.Auth/*.csproj ./Projects/SBA.Auth/

COPY Published/nuget.config ./GLOB/GLOB.Domain/
COPY Published/nuget.config ./Projects/SBA.Auth/
COPY Published/GLOB.*.nupkg ./Published/
COPY GlobalUsings.cs ./

# Restore dependencies
RUN --mount=type=cache,target=/root/.nuget/packages,sharing=locked,id=nuget-cache \
    dotnet restore ./Projects/SBA.Auth/SBA.Auth.csproj \
        --property:UseNuget=true \
        --configfile ./Projects/SBA.Auth/nuget.config \
        --verbosity detailed

# Copy the rest of the source files
# COPY GLOB/GLOB.API.Config/ ./GLOB/GLOB.API.Config/
# COPY GLOB/GLOB.Infra/ ./GLOB/GLOB.Infra/
# COPY GLOB/GLOB.API/ ./GLOB/GLOB.API/

COPY GLOB/GLOB.Domain/ ./GLOB/GLOB.Domain/
COPY Projects/SBA.Auth/ ./Projects/SBA.Auth/

# Build and publish
WORKDIR /app/Projects/SBA.Auth
RUN --mount=type=cache,target=/root/.nuget/packages,sharing=locked,id=nuget-cache \
    dotnet publish SBA.Auth.csproj -c Release -o /app/out \
        --property:UseNuget=true \
        --no-restore

# Stage 2: Runtime
FROM local/runtime:9.0
WORKDIR /app/Projects/SBA.Auth

# Copy the published app from build stage
COPY --from=sdk /app/out .

# Runtime environment variables (can be overridden at runtime via CLI, Docker Compose, etc.)
ENV DOTNET_ENVIRONMENT=Development
ENV Kestrel__Endpoints__Https__Certificate__Path="/app/dev-cert.pfx"
ENV Kestrel__Endpoints__Http__Url="http://+:1104"
ENV Kestrel__Endpoints__Https__Url="https://+:1105"
# ENV USE_HTTPS=true

ENV ConnectionStrings__SqlConnection="Server=sba-dev-sql,1433;Initial Catalog=SBA_Docker_Auth;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;"
ENV ConnectionStrings__Redis="sba-dev-redis:6379,password=P@55w0rd!123"

ENV Clients__RabbitMQz__Uri="amqps://unique-id-here.mq.ap-southeast-2.amazonaws.com"
ENV Clients__RabbitMQz__HostName="sba-dev-rmq"

# HTTP base addresses (internal communication)
ENV Clients__Httpz__Gateway="http://srvc-gateway:1100"
ENV Clients__Httpz__Job="http://srvc-job:1102"
ENV Clients__Httpz__Auth="http://srvc-auth:1104"
ENV Clients__Httpz__Hierarchy="http://srvc-hierarchy:1106"

# gRPC (HTTPS)
ENV Clients__Grpc__Protocols="Http2"
ENV Clients__Grpc__Gateway="https://srvc-gateway:1101"
ENV Clients__Grpc__Job="https://srvc-job:1103"
ENV Clients__Grpc__Auth="https://srvc-auth:1105"
ENV Clients__Grpc__Hierarchy="https://srvc-hierarchy:1107"

EXPOSE 1104
EXPOSE 1105


COPY ./Projects/SBA.Auth/startup.sh .
RUN chmod +x startup.sh
ENTRYPOINT ["./startup.sh"]

# ENTRYPOINT [ "dotnet", "SBA.Auth.dll" ]