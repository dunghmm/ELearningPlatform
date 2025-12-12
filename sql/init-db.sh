#!/bin/bash

# Wait for SQL Server to start
echo "Waiting for SQL Server to start..."
until /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -Q "SELECT 1" &> /dev/null
do
    sleep 2
done

echo "SQL Server is up, running init script..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -i /sql/init.sql
echo "Database initialized."