# Most used commands

## Docker-compose

### Build images

```powershell
    > cli/build.ps1
```

```sh
    sh cli/nmro.sh build
```

### Build a netcore image

```powershell
    > cli/build.ps1 <service-name ...>
```

```sh
    sh cli/nmro.sh build slnbased <service-name ...>
```

### Rebuild a running container service

```powershell
    Write-Host "will implement soon"
```

```sh
    sh cli/nmro.sh up -d --build <service-name>
```

### Run services

```powershell
    Write-Host "will implement soon"
```

```sh
    sh cli/nmro.sh up -d 
```

### Stop & remove all containers

```powershell
    cli/down.ps1
```

```sh
    sh cli/nmro.sh down 
```
