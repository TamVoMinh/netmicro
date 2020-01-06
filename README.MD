# README

## Overview

## Getting started

### How to setup development environment

### How to run up the system

1. Add local dns

    ```powershell
        > set-executionpolicy unrestricted
        # Then cd to root folder and execute
        > src\Deploy\dns.local.ps1
    ```

1. Copy & rename environment variable

    ```powershell
        # copy src\Deploy\variables.env.template to src/env
    ```

1. run up with docker-compose

    ```powershell
        > docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
    ```

## Coding conventions

### Server side projects in `C#`

* Reply on [StyleCop](https://github.com/StyleCop/StyleCop.ReSharper)
* Support tool reshaper

### Client side projects

* For `Typescript & Angular` [Use angular style guide](https://angular.io/guide/styleguide)
* For `Javascript` module reply on jslint/eslint and be supported by prettier
* For `Markdown` document use [style-guide](https://arcticicestudio.github.io/styleguide-markdown/rules/)
