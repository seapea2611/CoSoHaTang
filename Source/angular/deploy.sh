#!/bin/bash

docker run -d --name asdhrm-frontend \
  --network asdhrm \
  -p 4200:80 \
  asdhrm-frontend
