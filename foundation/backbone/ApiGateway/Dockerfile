FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine3.10 AS base
RUN apk --no-cache add curl
WORKDIR /app
EXPOSE 80

FROM monorepo AS build

WORKDIR /netmicro/foundation/backbone/ApiGateway
RUN dotnet restore -nowarn:msb3202,nu1503
RUN dotnet build --no-restore -c Release -o /artifact

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /artifact

FROM base AS final
WORKDIR /app
COPY --from=publish /artifact .
ENTRYPOINT ["dotnet", "Nmro.Foundation.Backbone.ApiGateway.dll"]
