### Certificate
- Creating it
```bash
mkdir certs
dotnet dev-certs https -ep ./certs/dev-cert.pfx -p yourpassword
dotnet dev-certs https --trust
```
- Setting ENV
```yml
    env:
    - name: DOTNET_ENVIRONMENT
        value: K8S
    - name: Kestrel__Endpoints__Http__Url
        value: "http://+:1104"
    - name: Kestrel__Endpoints__Http__Protocols
        value: "Http1"
    - name: Kestrel__Endpoints__Https__Url
        value: "https://+:1105"
    - name: Kestrel__Endpoints__Https__Protocols
        value: "Http2"
    - name: Kestrel__Endpoints__Https__Certificate__Path
        value: "certs/dev-cert.pfx"
    - name: Kestrel__Endpoints__Https__Certificate__Password
        value: "yourpassword"
```
- Adding it in the Project
```xml
  <ItemGroup>
    <None Include="..\certs\dev-cert.pfx" Link="certs\dev-cert.pfx" CopyToOutputDirectory="Always" />
  </ItemGroup>
```