#!/bin/bash

docker rm -f asdhrm-nginx asdhrm-frontend asdhrm-backend asdhrm-db

# Build images
docker build -t asdhrm-db ./mssql
docker build --no-cache -t asdhrm-backend ./aspnet-core
docker build -t asdhrm-frontend ./angular
docker build -t asdhrm-nginx ./nginx

# Deploy database
./mssql/deploy.sh

# Deploy backend
./aspnet-core/deploy.sh

# Deploy frontend
./angular/deploy.sh

# Deploy Nginx
./nginx/deploy.sh
