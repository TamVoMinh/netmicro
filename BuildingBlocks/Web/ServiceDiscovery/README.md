# How to use

## 1. Add config session to appsettings.json 
```JSON
{
    "ServiceDiscovery": {
        "serviceDiscoveryAddress": "http://consul:8500",
        "serviceName": "landing",
        "serviceId": "1",
        "serviceAddress": "http://landing:80"
    }
}
```

## 1. Add Add ServiveRegister in Startup.cs

```C#
using Nmro.BuildingBlocks.Web.ServiceDiscovery;
//...

public Startup(IConfiguration configuration)
{
    Configuration = configuration;
}

public void ConfigureServices(IServiceCollection services)
{
    //...
    services.RegisterConsulServices(Configuration);
}
```
