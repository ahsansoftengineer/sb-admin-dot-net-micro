### Hosting Nuget Packages Locally
- Adding Local Dir to Nuget Source
```bash
dotnet nuget add source "C:\Packages" --name Packages 
```
- Hosting Nuget Packages Locally
```bash
docker run -d -p 5555:80 -v C:/Packages:/var/baget --name baget loicsharma/baget
# dotnet nuget update source LocalBaGet --store-password-in-clear-text --configfile nuget.config --valid-authentication-types basic --allow-insecure-connections
docker stop baget
docker remove baget
docker start baget
```
- Publishing the Local Packages to Local Feed
```bash
dotnet nuget push MyLib.1.0.0.nupkg --source LocalBaGet --api-key xxy23343
```
```bash
curl -v http://host.docker.internal:5555/v3/index.json
curl -v http://localhost:5555/v3/index.json
```