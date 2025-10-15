### Pulling for Cache
```bash
docker pull mcr.microsoft.com/dotnet/sdk:9.0 
docker pull mcr.microsoft.com/dotnet/aspnet:9.0
```

### Preventing Excedently Delete
```bash
docker run -d --name keep-dotnet-sdk mcr.microsoft.com/dotnet/sdk:9.0 tail -f /dev/null
docker run -d --name keep-dotnet-aspnet mcr.microsoft.com/dotnet/aspnet:9.0 tail -f /dev/null

docker tag mcr.microsoft.com/dotnet/sdk:9.0 local/dotnet-sdk:cache
docker tag mcr.microsoft.com/dotnet/aspnet:9.0 local/dotnet-aspnet:cache
```

