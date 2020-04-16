# Most used commands

## Docker-compose

if you are using powershell. Make sure gitbash has been installed and let obmit `sh` in the commands below.

### Build images

```sh
    sh cli/nmro.sh build
```

### Build a netcore image

```sh
    sh cli/nmro.sh build slnbased <service-name ...>
```

### Rebuild a running container service

```sh
    #Need to list slnbased to copy the new source-code
    sh cli/nmro.sh up -d --force-recreate --build slnbased <service-name>
```

### Run services

```sh
    sh cli/nmro.sh up -d
```

### Stop & remove all containers

```sh
    sh cli/nmro.sh down
    sh cli/nmro.sh clear
```
