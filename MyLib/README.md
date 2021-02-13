# For C# demo

simple C# (.Net Core) example

>  Requires :
>	Visual Studio 2017 + .NET Framework 4.5

## How to build

> https://docs.microsoft.com/fr-fr/dotnet/core/tools/dotnet-build

In the terminal, run the following commands :
```
cd greeting
// for debug
dotnet build

// for release
//dotnet build -c Release
```
greeting.dll is generated in bin/Debug/netstandard2.O folder


## Test Lib

Run the following commands
```
cd greetings.Tests
dotnet test
```
> good tuto here : https://docs.microsoft.com/fr-fr/dotnet/core/testing/unit-testing-with-dotnet-test


## Generate a Nuget package 

> Lib has to be generated first

This method shows how to generate a nuget package from a DLL.

> see https://garywoodfine.com/creating-nuget-package-net-core/


1. Preparation

Edit greeting.csproj
```
<PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <GeneratePackageOnBuild>true</GeneratePackageOnBuild>
    <Version>0.0.1</Version>
    <PackageRequireLicenseAcceptance>true</PackageRequireLicenseAcceptance>
    <Company/>
    <Authors>yann chaysinh</Authors>
    <PackageProjectUrl/>
    <PackageIconUrl/>
    <PackageTags>ych greeting</PackageTags>
    <Copyright/>
    <Description>My greeting lib</Description>
    <PackageLicenseUrl>https://opensource.org/licenses/MIT</PackageLicenseUrl>
    <NeutralLanguage>en</NeutralLanguage>
    <RepositoryUrl>https://github.com/cyan21/</RepositoryUrl>
    <RepositoryType>git</RepositoryType>
</PropertyGroup>
```

2. Generate the nuget package

```
cd greeting
dotnet pack -c Release /p:PackageVersion=1.0.0
```

3. Configure Artifactory

* Windows

```
nuget sources Add -Name Artifactory -Source http://192.168.41.41:8081/artifactory/api/nuget/nuget
nuget setapikey admin:<PASSWORD> -Source Artifactory
```

* Linux

```
dotnet nuget add source http://192.168.41.41:8081/artifactory/api/nuget/dark-nuget -n art7 -u yann -p chaysinh --store-password-in-clear-text
```

4. Disable Nuget source

* Windows

```
nuget sources disable -Name nuget.org
```

* Linux

```
dotnet nuget list source
dotnet nuget disable source nuget.org
```


5. Push the nuget package to Artifactory

* Windows

```
dotnet nuget push <PATH_TO_PKG>/Greeting.1.0.0.nupkg --source Artifactory
```

* Linux

```
dotnet nuget push bin/Debug/Greeting.0.0.1.nupkg -k yann:chaysinh -s http://192.168.41.41:8081/artifactory/api/nuget/dark-nuget
```