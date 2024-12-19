#!/bin/bash

docker run -d --name asdhrm-backend \
  -e "ConnectionStrings__Default=Server=asdhrm-db;Database=HrmDb;User Id=sa;Password=123qwe@A;" \
  -e "ASPNETCORE_ENVIRONMENT=Development" \
  --network asdhrm \
  asdhrm-backend
