#!/bin/bash

docker run -d --name asdhrm-nginx \
  --network asdhrm \
  -p 80:80 \
  asdhrm-nginx
