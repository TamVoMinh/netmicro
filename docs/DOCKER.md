# Most used commands

## Docker-compose

if you are using powershell. Make sure gitbash has been installed and let obmit `sh` in the commands below.

### Build images

```sh
    sh devops/cli/nmro.sh build
```

### Build a netcore image

```sh
    sh devops/cli/nmro.sh build monorepo <service-name ...>
```

### Rebuild a running container service

```sh
    #Need to list monorepo to copy the new source-code
    sh devops/cli/nmro.sh up -d --force-recreate --build monorepo <service-name>
```

### Run services

```sh
    sh devops/cli/nmro.sh up -d
```

### Stop & remove all containers

```sh
    sh devops/cli/nmro.sh down
    sh devops/cli/nmro.sh clear
```
