FROM mcr.microsoft.com/mssql/server:2022-latest

USER root

# Install dependencies for sqlcmd
RUN apt-get update && \
    apt-get install -y curl gnupg && \
    curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/ubuntu/22.04/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && ACCEPT_EULA=Y apt-get install -y msodbcsql17 mssql-tools && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

# Create a directory for backups
RUN mkdir -p /var/opt/mssql/backups

# Copy the backup file into the container
COPY HrmDb.bak /var/opt/mssql/backups/HrmDb.bak

# Set environment variables (make sure these are set correctly during build)
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=123qwe@A

# Restore the database during the build process
# We use a separate RUN command to leverage Docker layer caching
RUN /opt/mssql/bin/sqlservr & \
    # Wait for SQL Server to start (give it some time)
    sleep 30s && \
    /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "$SA_PASSWORD" -Q " \
        RESTORE DATABASE HrmDb \
        FROM DISK = '/var/opt/mssql/backups/HrmDb.bak' \
        WITH \
          MOVE 'HrmDb' TO '/var/opt/mssql/data/HrmDb.mdf', \
          MOVE 'HrmDb_log' TO '/var/opt/mssql/data/HrmDb_log.ldf'; \
    " && \
    pkill -f sqlservr

USER mssql

# Expose the default SQL Server port
EXPOSE 1433

# Start SQL Server when the container runs
CMD ["/opt/mssql/bin/sqlservr"]
