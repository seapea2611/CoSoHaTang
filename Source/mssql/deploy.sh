docker run -d --name asdhrm-db \
  -e "ACCEPT_EULA=Y" \
  -e "SA_PASSWORD=123qwe@A" \
  --network asdhrm \
  -v asdhrm-db:/var/opt/mssql \
  -v $(pwd)/HrmDb.bak:/var/opt/mssql/backups/HrmDb.bak \
  asdhrm-db

sleep 30

docker exec -it asdhrm-db /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "123qwe@A" -Q "
RESTORE DATABASE HrmDb FROM DISK = '/var/opt/mssql/backups/HrmDb.bak'
WITH MOVE 'HrmDb' TO '/var/opt/mssql/data/HrmDb.mdf',
MOVE 'HrmDb_log' TO '/var/opt/mssql/data/HrmDb_log.ldf';"
