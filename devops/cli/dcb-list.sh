#!/bin/bash
_COMPOSES=(
    -f docker-compose.yml
    -f foundation/backbone/docker-compose.yml
    -f foundation/backings/docker-compose.yml
    -f business/security/docker-compose.yml
    -f business/portal/docker-compose.yml
    -f business/clients/docker-compose.yml
)


