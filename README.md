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
        > Copy-Item -Path Scripts\variables.env.template -Destination .env
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
        > DevOps\build.ps1
    ```

1. Known issues:

    - "logspout" service failed to build on windown, reference [issues/11](https://github.com/TamVoMinh/netmicro/issues/11)

1. Most used [commands](Docs/DOCKER.md)

### Playground with

1. Start playing around with [Landing site](http://nmro.local/) Implemented Hybrid-Flow for tradtional website
1. Discovery servcies with [Consul](http://isys.nmro.local/)
1. Analysis logging with [Kibana](http://isys.nmro.local/elk/)
1. Monitor health with [healthchecks-ui](http://isys.nmro.local/health/status/)
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

## Contributors
<!-- ALL-CONTRIBUTORS-BADGE:START - Do not remove or modify this section -->
[![All Contributors](https://img.shields.io/badge/all_contributors-5-orange.svg?style=flat-square)](#contributors)
<!-- ALL-CONTRIBUTORS-BADGE:END --> 
 <!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="https://github.com/TamVoMinh"><img src="https://avatars2.githubusercontent.com/u/21242164?v=4" width="100px;" alt=""/><br /><sub><b>TamVo</b></sub></a></td>
    <td align="center"><a href="https://github.com/minhhuan2210"><img src="https://avatars1.githubusercontent.com/u/43345758?v=4" width="100px;" alt=""/><br /><sub><b>Minh Huan</b></sub></a></td>
    <td align="center"><a href="https://github.com/duybt"><img src="https://avatars3.githubusercontent.com/u/16505992?v=4" width="100px;" alt=""/><br /><sub><b>Duy Bui</b></sub></a></td>
    <td align="center"><a href="https://github.com/VuDangKhoa1993"><img src="https://avatars1.githubusercontent.com/u/26622008?v=4" width="100px;" alt=""/><br /><sub><b>Dang Khoa</b></sub></a></td>
    <td align="center"><a href="https://github.com/tuantran-dev"><img src="https://avatars2.githubusercontent.com/u/60919379?v=4" width="100px;" alt=""/><br /><sub><b>tuantran-dev</b></sub></a></td>
  </tr>
</table>

<!-- markdownlint-enable -->
<!-- prettier-ignore-end -->
<!-- ALL-CONTRIBUTORS-LIST:END -->

