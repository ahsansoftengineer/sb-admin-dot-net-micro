### Hosting Nuget Packages Locally
- Adding Local Dir to Nuget Source
```bash
dotnet nuget add source "C:\Packages" --name Packages 
```
- Hosting Nuget Packages Locally
```bash
docker run -d -p 5555:80 -v C:/Packages:/var/baget --name baget loicsharma/baget
docker stop baget
docker start baget
```
- Publishing the Local Packages to Local Feed
```bash
dotnet nuget push MyLib.1.0.0.nupkg --source LocalBaGet --api-key xxy23343
```

- [Hosted Location](http://localhost:5555/v3/index.json)