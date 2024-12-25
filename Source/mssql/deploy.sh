#!/bin/bash

docker run -d --name asdhrm-db \
  -e "ACCEPT_EULA=Y" \
  -e "SA_PASSWORD=123qwe@A" \
  -p 1433:1433 \
  --network asdhrm \
  --network-alias asdhrm-db \
  -v asdhrm-db:/var/opt/mssql \
  asdhrm-db
