# README

## Overview

![Architect](Docs/Images/architect.png)

## Getting started

### How to setup development environment

### How to run up the system

1. Add local dns

    ```powershell
        > set-executionpolicy unrestricted
        # Then cd to root folder and execute
        > DevOnly\Scripts\dns.local.ps1
    ```

1. Copy & rename environment variable

    ```powershell
        > Copy-Item -Path DevOnly\Scripts\variables.env.template -Destination .env
    ```

1. Restore solution nuget packages to local folder (To speed up build without downloading next time)

    ```powershell
        >  dotnet restore .\Nmro.sln
    ```

1. Run Up IAM database

    ```powershell
        .\cli\nmro.sh up -d db-postgres
    ```

1. Drop existing schema **Skip this at first time**.

    ```powershell
        > Set-Location Services/IAM/Persistence | dotnet ef database drop
    ```

1. Initialize database schema

    ```powershell
        > Set-Location Services/IAM/Persistence | dotnet ef database update
    ```

1. Run up with docker-compose

    ```powershell
        # First time of running, it will take around 20mins for downloading images & build
        cli\nmro.sh up -d
    ```

1. Known issues:

    - "logspout" service failed to build on windown, reference [issues/11](https://github.com/TamVoMinh/netmicro/issues/11)

1. Most used [commands](Docs/DOCKER.md)

### Login information

1. Landing: User/Pass → admin/admin123
1. Kibana: User/Pass → elastic/changeme

### Playground with

1. [Landing site](http://nmro.local/) Implemented Hybrid-Flow for tradtional website
1. [Consul](http://isys.nmro.local/)
1. [Kibana](http://isys.nmro.local/elk/)
1. [healthchecks-ui](http://isys.nmro.local/health/status/)
1. [Redis Db](http://isys.nmro.local/redis/)
1. [control-centre](http://control-centre.nmro.local/) Implemented PKCE-Flow for angular app.
1. [swagger-ui](http://docs.nmro.local/)

## Coding conventions & Style

### Editors and IDEs

* For `define and maintain consistent` between different editors and IDEs [use EditorConfig](http://editorconfig.org)

### Server side projects in `C#`

* Reply on [StyleCop](https://github.com/StyleCop/StyleCop.ReSharper)
* Support tool reshaper

### Client side projects

* For `Typescript & Angular` [Use angular style guide](https://angular.io/guide/styleguide)
* For `Javascript` module reply on jslint/eslint and be supported by prettier
* For `Markdown` document use [style-guide](https://arcticicestudio.github.io/styleguide-markdown/rules/)
