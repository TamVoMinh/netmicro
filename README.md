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

1. Run Up IAM database

    ```powershell
        .\cli\nmro.sh up -d db-postgres
    ```

1. Drop existing schema **Skip this at first time**.

    ```powershell
        > Set-Location Services/IAM | dotnet ef database drop
    ```

1. Initialize database schema

    ```powershell
        > Set-Location Services/IAM | dotnet ef database update
    ```

1. Run up with docker-compose

    ```powershell
        cli\nmro.sh up -d
    ```

1. Known issues:

    - "logspout" service failed to build on windown, reference [issues/11](https://github.com/TamVoMinh/netmicro/issues/11)

1. Most used [commands](Docs/DOCKER.md)

### Playground with

1. Start playing around with [Landing site](http://nmro.local/) Implemented Hybrid-Flow for tradtional website
1. Discovery servcies with [Consul](http://isys.nmro.local/)
1. Analysis logging with [Kibana](http://isys.nmro.local/elk/)
1. Monitor health with [healthchecks-ui](http://isys.nmro.local/health/status/)
1. Explore  [Redis Db](http://isys.nmro.local/redis/)
1. Play with [control-centre](http://control-centre.nmro.local/) Implemented PKCE-Flow for angular app.
1. Enjoy document with [swagger-ui](http://docs.nmro.local/)
1. User/Pass: admin/admin123

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
