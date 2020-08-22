#!/bin/bash
_COMPOSES=(
    -f docker-compose.yml
    -f foundation/backbone/docker-compose.yml
    -f foundation/backings/docker-compose.yml
    -f capacities/security/docker-compose.yml
    -f capacities/portal/docker-compose.yml
    -f capacities/clients/docker-compose.yml
)


