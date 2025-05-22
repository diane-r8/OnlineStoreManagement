@echo off

REM Set path to MySQL command-line tool
set MYSQL_PATH="C:\Program Files\MySQL\MySQL Server 8.0\bin\mysql.exe"

REM Start MySQL service (change service name if different)
net start MySQL80

REM Wait 5 seconds to ensure MySQL service starts
timeout /t 5

echo Creating database and granting privileges...
%MYSQL_PATH% -u root --connect-expired-password < "%~dp0init_db.sql"

echo Restoring OnlineStoreDB dump...
%MYSQL_PATH% -u root onlinestore < "%~dp0OnlineStoreDB.sql"

echo Database restoration complete.
