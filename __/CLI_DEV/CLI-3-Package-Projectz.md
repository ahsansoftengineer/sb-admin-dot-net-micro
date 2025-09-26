### API GATEWAY
```bash
dotnet add ./Projects/SBA.APIGateway/ package MMLib.SwaggerForOcelot -v 8.0.0
```
### Job
```bash
dotnet add ./Projects/SBA.Job/ package Hangfire -v 1.8.20
dotnet add ./Projects/SBA.Job/ package Hangfire.Core -v 1.8.20
dotnet add ./Projects/SBA.Job/ package Hangfire.Storage.SQLite -v 0.4.2
dotnet add ./Projects/SBA.Job/ package Hangfire.Dashboard.Basic.Authentication -v 8.0.0
```

### Auth
```bash
dotnet add ./Projects/SBA.Auth/ package Microsoft.EntityFrameworkCore.Tools -v 9.0.0
dotnet add ./Projects/SBA.Auth/ package Microsoft.AspNetCore.Authentication.Google
dotnet add ./Projects/SBA.Auth/ package Grpc.Tools -v 2.72.0
```

### Hierarchy
```bash
dotnet add ./Projects/SBA.Auth/ package Microsoft.EntityFrameworkCore.Tools -v 9.0.0
dotnet add ./Projects/SBA.Auth/ package Grpc.Tools -v 2.72.0
```