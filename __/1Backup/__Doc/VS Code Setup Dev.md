Awesome — here’s a concise **internal documentation draft** you can include in your repo (`README`, `docs/setup.md`, or a shared team wiki) for onboarding or maintaining the setup.

---

## 🧩 SBA Microservices Dev Environment — Internal Setup Guide

This document outlines the local development setup for the SBA Microservices ecosystem, including API Gateway routing via Ocelot, multi-service debugging, and Swagger support — all without needing `tasks.json`.

---

### 📁 Project Structure (Relevant Services)
```
/SBA.APIGateway
/SBA.Auth
/SBA.Hierarchy
...
```

---

## ⚙️ VS Code Debugging Setup

**File:** `.vscode/launch.json`

- Uses `dotnet watch run` to support hot reload.
- Runs multiple services simultaneously with a single command.
- No need for `tasks.json`.

### 🔧 Launch Configurations
Each service uses:
```json
{
  "name": "SBA.ServiceName",
  "type": "coreclr",
  "request": "launch",
  "program": "dotnet",
  "args": [
    "watch", "run", "--project", "${workspaceFolder}/SBA.ServiceName/SBA.ServiceName.csproj", "--launch-profile", "https"
  ],
  ...
}
```

### 🧪 Compound Debugging
```json
{
  "name": "Watch Build Debug All Services",
  "configurations": ["SBA.APIGateway", "SBA.Auth", "SBA.Hierarchy"]
}
```

---

## 🌐 API Gateway — Ocelot

**File:** `SBA.APIGateway/ocelot.json`

### Key Routes:
| Service   | Local Port | Upstream Path               |
|-----------|------------|-----------------------------|
| Auth      | 1102       | `/api/auth/v1/{everything}` |
| Hierarchy | 1106       | `/api/hierarchy/v1/...`     |
| Swagger   | -          | `/swagger-doc/swagger.json` |

### Sample Route Mapping:
```json
{
  "DownstreamPathTemplate": "/api/auth/v1/{everything}",
  "DownstreamHostAndPorts": [{ "Host": "localhost", "Port": 1102 }],
  "UpstreamPathTemplate": "/api/auth/v1/{everything}"
}
```

> `GlobalConfiguration.BaseUrl`: `http://localhost:1100`

---

## 🌍 Local Environment Settings

**Each service includes:**

### `launchSettings.json`
- Configures HTTPS profiles with specific ports
- Launch browser set to true
- Profile: `https`

### `Option_App.json`
```json
"ASPNETCORE_HTTPS_PORT": "1101",
"ASPNETCORE_ENVIRONMENT": "Development",
"USE_HTTPS": false,
"OcelotFileName": "ocelot.json"
```

### Swagger Services (API Gateway)
```json
"SwaggerServices": [
  {
    "Name": "Auth Service",
    "Url": "/api/Auth/v1/swagger-doc/swagger.json"
  }
]
```

---

## 🧪 To Start All Services

1. Open **Run & Debug** tab in VS Code.
2. Select **"Watch Build Debug All Services"** compound.
3. Press **Start Debugging** ▶️.

---

## 📌 Notes

- `tasks.json` not required due to `dotnet watch run`.
- You can easily expand to add more services.
- Swagger is routed through the API Gateway — great for aggregation tools like SwaggerUI, ReDoc, or custom docs portals.
- Supports HTTPS, but fallback to HTTP available for flexibility.

---

Let me know if you want this saved as a markdown file, or tailored for GitHub, Notion, or Confluence — I can format accordingly.