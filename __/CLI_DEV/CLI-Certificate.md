### Certificate
#### Local Host Certificate
- This approach has a flow the Certificate Only works with localhost
```bash
dotnet dev-certs https -ep ./dev-cert.pfx -p P@ssw0rd!
dotnet dev-certs https --trust
```
- ENV appsettings.json
```json
{
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://localhost:1106",
        "Protocols": "Http1"
      },
      "Https": {
        "Url": "https://localhost:1107",
        "Protocols": "Http2",
        "Certificate": {
          "Path": "../../dev-cert.pfx",
          "Password": "P@ssw0rd!"
        }
      }
    }
  },
 "Clients":{
    "Grpc": {
      "Protocols": "Http2",
      "Gateway": "https://localhost:1101",
      "Job": "https://localhost:1103",
      "Auth": "https://localhost:1105",
      "Hierarchy": "https://localhost:1107"
    }
  }

}

```

#### Certificate with Different Domains
- This approach work with Docker and Localhost
- Powershell Command
```bash
# Creating Certificate
New-SelfSignedCertificate `
  -DnsName "localhost","srvc-auth","srvc-job","srvc-hierarchy","srvc-gateway" `
  -FriendlyName "SBA Dev Cert" `
  -CertStoreLocation "cert:\CurrentUser\My" `
  -NotAfter (Get-Date).AddYears(5)

# Verify
Get-ChildItem -Path Cert:\CurrentUser\My | Where-Object {$_.FriendlyName -eq "SBA Dev Cert"} | Select-Object FriendlyName, Thumbprint

# Paste Certificate to Location
$pwd = ConvertTo-SecureString -String "P@ssw0rd!" -Force -AsPlainText
Export-PfxCertificate `
  -Cert "cert:\CurrentUser\My\F242DE3CCF8A9493881630F6BDDF04A11F550699" `
  -FilePath "C:\D\net-micro\dev-cert.pfx" `
  -Password $pwd

```
- ENV Docker 
```Dockerfile
ENV DOTNET_ENVIRONMENT=Development
ENV Kestrel__Endpoints__Https__Certificate__Path="/app/dev-cert.pfx"
ENV Kestrel__Endpoints__Http__Url="http://+:1106"
ENV Kestrel__Endpoints__Https__Url="https://+:1107"
# ENV USE_HTTPS=true

# gRPC (HTTPS)
ENV Clients__Grpc__Protocols="Http2"
ENV Clients__Grpc__Gateway="https://srvc-gateway:1101"
ENV Clients__Grpc__Job="https://srvc-job:1103"
ENV Clients__Grpc__Auth="https://srvc-auth:1105" 
ENV Clients__Grpc__Hierarchy="https://srvc-hierarchy:1107"
```