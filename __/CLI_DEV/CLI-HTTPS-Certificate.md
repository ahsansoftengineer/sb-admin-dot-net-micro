### Certificate
- [Microsoft Docs](https://learn.microsoft.com/en-us/aspnet/core/security/docker-https?view=aspnetcore-9.0)
- [Youtube](https://www.youtube.com/watch?v=EnY6fSng3Ew&t=3s)


#### Local Host Certificate
- This approach has a flow the Certificate Only works with localhost
```bash
dotnet dev-certs https -ep ./dev-cert.pfx -p P@ssw0rd!123
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
          "Password": "P@ssw0rd!123"
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
# Creating Certificate (Works)
New-SelfSignedCertificate `
  -DnsName "localhost","srvc-auth","srvc-job","srvc-hierarchy","srvc-gateway" `
  -FriendlyName "SBA Dev Cert" `
  -CertStoreLocation "cert:\CurrentUser\My" `
  -NotAfter (Get-Date).AddYears(5)

# Verify
Get-ChildItem -Path Cert:\CurrentUser\My | Where-Object {$_.FriendlyName -eq "SBA Dev Cert"} | Select-Object FriendlyName, Thumbprint
# Get-ChildItem -Path Cert:\CurrentUser\My | Where-Object { $_.FriendlyName -eq "SBA Dev Cert" } |Remove-Item

# Paste Certificate to Location (Works)
$pwd = ConvertTo-SecureString -String "P@ssw0rd!123" -Force -AsPlainText
Export-PfxCertificate `
  -Cert "cert:\CurrentUser\My\BFD9D53E970FB5F07CDA463650B60FB52836C893" `
  -FilePath "C:\D\net-micro\dev-cert.pfx" `
  -Password $pwd
Import-PfxCertificate `
  -FilePath "C:\D\net-micro\dev-cert.pfx" `
  -Password $pwd `
  -CertStoreLocation Cert:\CurrentUser\Root `
  -Exportable `
  -Confirm:$false
# Creating Certificate From PFX
dotnet dev-certs https -ep C:\D\net-micro\dev-cert.crt --format PEM


# Export the public root (no password)
Export-Certificate `
  -Cert "cert:\CurrentUser\My\BFD9D53E970FB5F07CDA463650B60FB52836C893" `
  -FilePath "C:\D\net-micro\dev-root-cert.crt"
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