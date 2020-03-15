# How to use

## 1. Add config session to appsettings.json 
```JSON
{
    "ServiceDiscovery": {
        "ServiceDiscoveryAddress": "http://consul:8500",
        "ServicePort": 80
    }
}
```

## 1. Add Add ServiveRegister in Startup.cs

```C#
using Nmro.BuildingBlocks.Web.ServiceDiscovery;
//...

public static readonly string AppName = "application-name";

public Startup(IConfiguration configuration)
{
    Configuration = configuration;
}

public void ConfigureServices(IServiceCollection services)
{
    //...
    services.RegisterConsulServices(Program.AppName, Configuration);
}
```
