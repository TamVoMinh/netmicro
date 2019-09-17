FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /released
COPY *.csproj ./
COPY . ./
RUN dotnet restore -nowarn:msb3202,nu1503 &\
    dotnet build --no-restore -c Release -o /released &\ 
    dotnet publish --no-restore -c Release -o /released

FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build /released/out ./
ENTRYPOINT ["dotnet", "Nmro.Uaa.dll"]
