# [Choice] .NET version: 7.0, 6.0, 5.0, 3.1, 6.0-bullseye, 5.0-bullseye, 3.1-bullseye, 6.0-focal, 5.0-focal, 3.1-focal
ARG VARIANT="7.0-bullseye-slim"
FROM mcr.microsoft.com/vscode/devcontainers/dotnet:0-${VARIANT}

RUN apt-get update && \
    export DEBIAN_FRONTEND=noninteractive && \
    apt-get -qy full-upgrade && \
    apt-get install -qy curl && \
    apt-get -y install --no-install-recommends vim && \
    curl -sSL https://get.docker.com/ | sh

# [Choice] Node.js version: none, lts/*, 16, 14, 12, 10
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash - && apt-get install -yq nodejs build-essential
# [Optional] Uncomment this section to install additional OS packages.


RUN dotnet tool install -g dotnet-ef

ENV PATH $PATH:/root/.dotnet/tools

# configure for https
RUN dotnet dev-certs https