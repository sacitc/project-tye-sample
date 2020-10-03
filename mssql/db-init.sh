sleep 15s
/opt/mssql-tools/bin/sqlcmd -i /usr/src/app/db-init.sql
# /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d master -i /usr/src/app/db-init.sql
