Ah — now I get exactly what you’re aiming for 👌

You don’t just want to **hide** dependencies.
You actually want to **publish a NuGet package that already contains all its dependent assemblies**, so that:

✅ The child project just references **your package**
✅ No separate `dotnet restore` for Newtonsoft.Json, etc.
✅ No internet dependency when restoring downstream projects.

This is often called **“fat NuGet”** or **self-contained NuGet** packaging.
NuGet **by design does not embed dependency packages as other packages** — it lists them as dependencies in the `.nuspec` file so child projects download them.

But there **are legitimate ways to do what you want** 👇

---

## 🧰 Option 1 — Pack All DLLs Inside Your NuGet (No Dependency Propagation)

This is the cleanest way to **embed the DLLs** directly in your NuGet under `lib/`.
Your package will behave like a self-contained library.

Add this to your `.csproj`:

```xml
<PropertyGroup>
  <TargetFramework>net9.0</TargetFramework>
  <IncludeBuildOutput>false</IncludeBuildOutput>  <!-- don't pack compiled dll automatically -->
</PropertyGroup>

<ItemGroup>
  <!-- Build the project and include its output -->
  <Content Include="$(OutputPath)\**\*.dll" Pack="true" PackagePath="lib\net9.0" />

  <!-- Optional: also embed pdb for debugging -->
  <Content Include="$(OutputPath)\**\*.pdb" Pack="true" PackagePath="lib\net9.0" />
</ItemGroup>
```

And in your publish/pack script:

```bash
dotnet build ./GLOB/GLOB.Extz/GLOB.Extz.csproj -c Release
dotnet pack ./GLOB/GLOB.Extz/GLOB.Extz.csproj -c Release
```

✅ This way:

* Your `GLOB.Extz.nupkg` will **contain its own DLL and referenced DLLs** (e.g. Newtonsoft.Json.dll).
* The `.nuspec` will have **no dependency entries** for Newtonsoft.Json.
* When a child project references your package, MSBuild just copies the DLLs to `bin/` — no NuGet fetch needed.

❗ Make sure `CopyLocalLockFileAssemblies=true` in your `.csproj` to copy dependencies into `$(OutputPath)` at build time:

```xml
<PropertyGroup>
  <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
</PropertyGroup>
```

---

## 🧰 Option 2 — Use `dotnet publish` and wrap that output

Instead of relying on `dotnet pack` behavior, you can:

1. `dotnet publish` the project (this generates a fully self-contained output folder with all dependencies).
2. Package the **published DLLs** manually into a `.nupkg` (either with a custom `.nuspec` or `.csproj` with `Content`).

```bash
dotnet publish GLOB.Extz.csproj -c Release -o ./publish
```

Then in `.csproj`:

```xml
<ItemGroup>
  <Content Include="publish\**\*.dll" Pack="true" PackagePath="lib\net9.0" />
</ItemGroup>
```

✅ Child projects will just consume your fat package, no restore of dependencies needed.

---

## 🧰 Option 3 — Create a “meta-package” (❌ not what you want)

This is the default NuGet behavior — just lists dependencies and lets downstream projects restore them.
(This is what you’re frustrated with.)

---

## 🚨 Things to watch out for:

* You need to **ensure no DLL conflicts** if downstream projects use the same libraries with different versions.
* Because you’re embedding everything, your NuGet will be larger in size.
* It won’t support transitive updates — if Newtonsoft.Json releases a patch, you’ll have to republish your package to get it.

---

✅ **Best for your case**: Use **Option 1** — pack all DLLs into `lib/net9.0` by disabling dependency listing and copying local assemblies during build.
This gives you exactly what you asked: one package — no external downloads.

Would you like me to show you exactly how the `.nuspec` looks after applying this (so you can verify no dependency is listed)?
