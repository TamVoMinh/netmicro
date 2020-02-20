# README

## Overview

## Getting started

### How to setup development environment

### How to run up the system

1. Add local dns

    ```powershell
        > set-executionpolicy unrestricted
        # Then cd to root folder and execute
        > Scripts\dns.local.ps1
    ```

1. Copy & rename environment variable

    ```powershell
        > Copy-Item -Path Scripts\variables.env.template -Destination .env
    ```

1. Run up with docker-compose

    ```powershell
        > docker-compose -f docker-compose.yml -f docker-compose.override.yml -f DevOnly/docker-compose.yml -f Elk/docker-compose.yml -f Clients/docker-compose.yml up -d
    ```

1. Clean Up local docker containers

    ```powershell
        > docker stop $(docker ps -q); docker rm $(docker ps -aq)
        > docker system prune
    ```

1. Known issues:

- "logspout" service failed to build on windown (ref: https://github.com/TamVoMinh/netmicro/issues/11)


### Playground with

1. Default [webiste writen on netcore MVC](http://nmro.local)
1. Analysis logging with [Kibana](http://isys.nmro.local/elk)
1. Monitor health with [healthchecks-ui](http://isys.nmro.local/health/status)
1. Api document with [swagger-ui](http://isys.nmro.local/health/status)
1. user/pass: admin/admin123

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

## Contributors
<!-- ALL-CONTRIBUTORS-BADGE:START - Do not remove or modify this section -->
[![All Contributors](https://img.shields.io/badge/all_contributors-13-orange.svg?style=flat-square)](#contributors)
<!-- ALL-CONTRIBUTORS-BADGE:END --> 
