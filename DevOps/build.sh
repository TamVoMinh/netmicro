#!/bin/bash
echo "services"  $1
docker-compose -f docker-compose.override.yml -f Backbone/docker-compose.yml -f DevOnly/docker-compose.yml -f Foundation/Elk/docker-compose.yml -f Services/docker-compose.yml -f Web/docker-compose.yml -f Clients/docker-compose.yml build --force-rm --parallel $1
docker image prune --filter "dangling=true"
