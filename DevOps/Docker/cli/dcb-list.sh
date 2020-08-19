#!/bin/bash
_COMPOSES=(
    -f docker-compose.yml
    -f Backbone/docker-compose.yml
    -f Backing/docker-compose.yml
    -f DevOnly/docker-compose.yml
    -f Services/docker-compose.yml
    -f Web/docker-compose.yml
    -f Clients/docker-compose.yml
)


