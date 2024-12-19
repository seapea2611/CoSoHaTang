FROM mcr.microsoft.com/mssql/server:2022-latest

USER root
RUN apt-get update && \
    apt-get install -y curl gnupg && \
    curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/ubuntu/22.04/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && ACCEPT_EULA=Y apt-get install -y msodbcsql17 mssql-tools && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

# Copy the backup file into the container
COPY HrmDb.bak /var/opt/mssql/backups/HrmDb.bak

# Set the SA password as an environment variable during build time
ENV SA_PASSWORD=123qwe@A
ENV ACCEPT_EULA=Y

# Restore the database during the build process
RUN /opt/mssql/bin/sqlservr & \
    sleep 30s && \
    /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $SA_PASSWORD -Q " \
        RESTORE DATABASE HrmDb \
        FROM DISK = '/var/opt/mssql/backups/HrmDb.bak' \
        WITH \
          MOVE 'HrmDb' TO '/var/opt/mssql/data/HrmDb.mdf', \
          MOVE 'HrmDb_log' TO '/var/opt/mssql/data/HrmDb_log.ldf'; \
    " && \
    pkill -f sqlservr

USER mssql
