# Most used commands

## Docker-compose

### Build images

```powershell
    > docker-compose -f docker-compose.yml -f docker-compose.override.yml -f DevOnly/docker-compose.yml -f Elk/docker-compose.yml -f Clients/docker-compose.yml build
```


### Build a netcore image

```powershell
    > docker-compose -f docker-compose.yml -f docker-compose.override.yml -f DevOnly/docker-compose.yml -f Elk/docker-compose.yml -f Clients/docker-compose.yml build slnbased <service-name-in-docker-compose-file>
```

### Rebuild a running container service

```powershell
    > docker-compose -f docker-compose.yml -f docker-compose.override.yml -f DevOnly/docker-compose.yml -f Elk/docker-compose.yml -f Clients/docker-compose.yml up -d --build slnbased slnbased <service-name-in-docker-compose-file>
```

### Run services

```powershell
    > docker-compose -f docker-compose.yml -f docker-compose.override.yml -f DevOnly/docker-compose.yml -f Elk/docker-compose.yml -f Clients/docker-compose.yml up -d
```

### Stop & remove all containers

```powershell
    > docker-compose -f docker-compose.yml -f docker-compose.override.yml -f DevOnly/docker-compose.yml -f Elk/docker-compose.yml -f Clients/docker-compose.yml down
```
