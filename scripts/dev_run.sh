#!/usr/bin/env bash
set -x
set -eo pipefail

dotnet run --project "Grit.HabitService" --no-build &

cd ./Grit.Client
yarn dev