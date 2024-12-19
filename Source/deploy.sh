#!/bin/bash

# Stop and remove any existing containers
docker stop asdhrm-db asdhrm-backend asdhrm-frontend asdhrm-nginx
docker rm asdhrm-db asdhrm-backend asdhrm-frontend asdhrm-nginx

# Build images
docker build -t asdhrm-db ./mssql
docker build -t asdhrm-backend ./aspnet-core
docker build -t asdhrm-frontend ./angular
docker build -t asdhrm-nginx ./nginx

# Deploy database
docker run -d --name asdhrm-db \
  -e "ACCEPT_EULA=Y" \
  -e "SA_PASSWORD=123qwe@A" \
  -p 1433:1433 \
  --network asdhrm \
  -v asdhrm-db:/var/opt/mssql \
  asdhrm-db

# Deploy backend
docker run -d --name asdhrm-backend \
  -e "ConnectionStrings__Default=Server=asdhrm-db;Database=HrmDb;User Id=sa;Password=123qwe@A;" \
  -e "ASPNETCORE_ENVIRONMENT=Development" \
  --network asdhrm \
  asdhrm-backend

# Deploy frontend
docker run -d --name asdhrm-frontend \
  --network asdhrm \
  asdhrm-frontend

# Deploy Nginx
docker run -d --name asdhrm-nginx \
  --network asdhrm \
  -p 80:80 \
  asdhrm-nginx

echo "Deployment complete!"
