
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.10
WORKDIR /netmicro

COPY "Nmro.sln" "Nmro.sln"
COPY "nuget.config" "nuget.config"
COPY "pkgs" "pkgs"

COPY "blocks/netcore/Shared/Nmro.Shared.csproj" "blocks/netcore/Shared/Nmro.Shared.csproj"
COPY "blocks/netcore/Hosting/Nmro.Hosting.csproj" "blocks/netcore/Hosting/Nmro.Hosting.csproj"

COPY "foundation/backbone/ApiGateway/Nmro.Foundation.Backbone.ApiGateway.csproj" "Foundation/backbone/ApiGateway/Nmro.Foundation.Backbone.ApiGateway.csproj"

COPY "business/security/IAM/Faces/Api/Nmro.Security.IAM.Faces.API.csproj" "business/security/IAM/Faces/Api/Nmro.Security.IAM.Faces.API.csproj"
COPY "business/security/IAM/Faces/Worker/Nmro.Security.IAM.Faces.Worker.csproj" "business/security/IAM/Faces/Worker/Nmro.Security.IAM.Faces.Worker.csproj"
COPY "business/security/IAM/Core/Nmro.Security.IAM.Core.csproj" "business/security/IAM/Core/Nmro.Security.IAM.Core.csproj"
COPY "business/security/IAM/Infras/Storage/Nmro.Security.IAM.Infras.Storage.csproj" "business/security/IAM/Infras/Storage/Nmro.Security.IAM.Infras.Storage.csproj"

COPY "business/security/Oidc/Nmro.Security.Oidc.csproj" "business/security/Oidc/Nmro.Security.Oidc.csproj"

COPY "business/portal/Landing/Nmro.Portal.Landing.csproj" "business/portal/Landing/Nmro.Portal.Landing.csproj"

COPY . .

RUN dotnet restore Nmro.sln
