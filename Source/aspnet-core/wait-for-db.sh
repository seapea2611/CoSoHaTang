#!/bin/bash

echo "Waiting for database to be ready..."

# Wait for the /tmp/db_ready_volume/db_ready file to be created (in the shared volume)
inotifywait -m /tmp/db_ready_volume -e create |
  while read dir action file; do
    if [[ "$file" == "db_ready" ]]; then
      echo "Database is ready!"
      exit 0
    fi
  done
