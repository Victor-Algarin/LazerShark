echo off

rem batch file to run a script to create a db
rem 10/27/2016

sqlcmd -s localhost -E -i lazerSharkDB.sql


ECHO if no error messages appear DB was created
PAUSE