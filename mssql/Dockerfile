FROM mcr.microsoft.com/mssql/server:2019-latest

USER root

RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

COPY . /usr/src/app

RUN chmod +x /usr/src/app/db-init.sh

EXPOSE 1433

USER mssql
ENTRYPOINT /bin/bash ./entrypoint.sh