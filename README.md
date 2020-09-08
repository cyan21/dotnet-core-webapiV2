# For C# demo

simple WebAPI example based on the dotnet CLI

How it was initialized  :

```
mkdir -p webapi-project/{MyWebAPI,MyWebAPI.Tests}
cd webapi-project
dotnet new sln 
cd MyWebAPI 
dotnet new webapi
dotnet build
dotnet run
```

## Customization
* rely on my custom Nuget package "Greeting" -> edit the MyWebAPI/MyWebAPI.csproj 
* added the "SayHiController.cs" in the Controller folder

## To test 
```
curl -k http://localhost:5000/api/weatherforecast
curl -k http://localhost:5000/api/sayhi/{fr,jp,en}
```
