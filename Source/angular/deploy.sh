#!/bin/bash

docker run -d --name asdhrm-frontend \
  --network asdhrm \
  asdhrm-frontend
