# How to use

## 1. Add config session to appsettings.json

```json
{
    "ServiceDiscovery": {
        "ServiceDiscoveryAddress": "http://consul:8500",
        "ServicePort": 80
    }
}
```

## 1. Add ServiveRegister to netcore app

```C#
//...
// Program.cs
 public class Program
{
    public static readonly string AppName = "application-name";
    public static int Main(string[] args)
    {
        //..
    }
}

// Startup.cs
using Nmro.Web.ServiceDiscovery;
//...
public Startup(IConfiguration configuration)
{
    Configuration = configuration;
}

public void ConfigureServices(IServiceCollection services)
{
    //...
    services.RegisterConsulServices(
        Program.AppName,
        option => Configuration.GetSection("ServiceDiscovery").Get<DiscoveryOptions>()
    );
}
```
