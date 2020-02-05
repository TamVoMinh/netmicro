FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine3.9 AS base
RUN apk --no-cache add curl
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine3.9 AS build
WORKDIR /src

ADD "Website" "Website"
COPY "Website/wwwroot" "Website/wwwroot"

WORKDIR /src/Website
RUN dotnet restore -nowarn:msb3202,nu1503
RUN dotnet build --no-restore -c Release -o /app

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Nmro.Landing.dll"]
