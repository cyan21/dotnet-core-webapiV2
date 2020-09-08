# For C# demo

simple WebAPI example based on the dotnet CLI

## Requirement

## Background

This project was created on ubuntu 

https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu

It was initialized by using the dotnet CLI

```
mkdir -p webapi-project/{MyWebAPI,MyWebAPI.Tests}
cd webapi-project
dotnet new sln 
cd MyWebAPI 
dotnet new webapi
dotnet build
```

## Customization
* rely on my custom Nuget package "Greeting" -> edit the MyWebAPI/MyWebAPI.csproj 
* added the "SayHiController.cs" in the Controller folder

## To test 

* run the server on localhost 
```
// from the  MyWebAPI folder
dotnet run

curl -L -k http://localhost:5000/api/weatherforecast
curl -L -k http://localhost:5000/api/sayhi/{fr,jp,en}
```
or 

* run the server on localhost 
```
// from the  MyWebAPI folder
// host IP : 192.168.21.22
dotnet run --urls "http://0.0.0.0:2000"

curl http://192.168.21.22:2000/api/weatherforecast
curl http://192.168.21.22:2000/api/sayhi/{fr,jp,en}
```
