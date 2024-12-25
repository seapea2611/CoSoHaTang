#!/bin/bash

docker run -d --name asdhrm-frontend \
  --network asdhrm \
  -p 4200:4200 \
  asdhrm-frontend
