# Most used commands

## Docker-compose

### Build images

```powershell
    > DevOps/build.ps1
```

```sh
    sh cli/nmro.sh
```

### Build a netcore image

```powershell
    > DevOps/build.ps1 <service-name ...>
```

```sh
    sh cli/nmro.sh build <service-name ...>
```

### Rebuild a running container service

```powershell
    Write-Host "will implement soon"
```

```sh
    echo "will implement soon"
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
    DevOps/down.ps1
```

```sh
    sh cli/nmro.sh down 
```
