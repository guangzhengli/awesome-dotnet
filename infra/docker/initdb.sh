#!/bin/bash
set -e

psql "postgres://$POSTGRES_USER:$POSTGRES_PASSWORD@$POSTGRES_HOST/$POSTGRES_DB?sslmode=disable" <<-EOSQL
	CREATE DATABASE awesome_dotnet;
	GRANT ALL PRIVILEGES ON DATABASE awesome_dotnet TO "$POSTGRES_USER";
EOSQL