
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.10 AS build
WORKDIR /netmicro

COPY "Nmro.sln" "Nmro.sln"

COPY "BuildingBlocks/WebHost/WebHost.csproj" "BuildingBlocks/WebHost/WebHost.csproj"

COPY "Gateways/ApiGateway/Nmro.ApiGateway.csproj" "Gateways/ApiGateway/Nmro.ApiGateway.csproj"

COPY "Services/IAM/Nmro.IAM.csproj" "Services/IAM/Nmro.IAM.csproj"
COPY "Services/Oidc/Nmro.Oidc.csproj" "Services/Oidc/Nmro.Oidc.csproj"

COPY "Web/Landing/Nmro.Landing.csproj" "Web/Landing/Nmro.Landing.csproj"
COPY "Web/Health/Nmro.Health.csproj" "Web/Health/Nmro.Health.csproj"

COPY . .

RUN dotnet restore Nmro.sln
