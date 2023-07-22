#!/usr/bin/env bash
set -x
set -eo pipefail

CONTAINER="dev_env"

start_container() {
    cd ./docker
    docker-compose -f docker-compose.yml up -d
    cd ../
}

if ! [ "$(  docker container inspect -f '{{.State.Running}}' $CONTAINER )" == "true" ]; then
    start_container
fi


