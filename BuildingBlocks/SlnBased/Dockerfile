
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.10
WORKDIR /netmicro

COPY "Nmro.sln" "Nmro.sln"
COPY "nuget.config" "nuget.config"
COPY "packages" "packages"

COPY "BuildingBlocks/Web/Web.csproj" "BuildingBlocks/Web/Web.csproj"

COPY "Backbone/ApiGateway/Nmro.ApiGateway.csproj" "Backbone/ApiGateway/Nmro.ApiGateway.csproj"

COPY "Services/IAM/API/Nmro.IAM.API.csproj" "Services/IAM/API/Nmro.IAM.API.csproj"
COPY "Services/IAM/Application/Nmro.IAM.Application.csproj" "Services/IAM/Application/Nmro.IAM.Application.csproj"
COPY "Services/IAM/Domain/Nmro.IAM.Domain.csproj" "Services/IAM/Domain/Nmro.IAM.Domain.csproj"
COPY "Services/IAM/Persistence/Nmro.IAM.Persistence.csproj" "Services/IAM/Persistence/Nmro.IAM.Persistence.csproj"

COPY "Services/Oidc/Nmro.Oidc.csproj" "Services/Oidc/Nmro.Oidc.csproj"

COPY "Web/Landing/Nmro.Landing.csproj" "Web/Landing/Nmro.Landing.csproj"
COPY "Web/Health/Nmro.Health.csproj" "Web/Health/Nmro.Health.csproj"


COPY . .

RUN dotnet restore Nmro.sln
