FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine3.10 AS base
RUN apk --no-cache add curl
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.10 AS build
WORKDIR /Web

ADD "/Web/Landing" "/Web/Landing"
COPY "/Web/Landing/wwwroot" "/Web/Landing/wwwroot"

WORKDIR /Web/Landing
RUN dotnet restore -nowarn:msb3202,nu1503
RUN dotnet build --no-restore -c Release -o /app

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Nmro.Landing.dll"]
