@echo off
echo ����ע��aspne4.0��iis
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\aspnet_regiis.exe -i
C:\Windows\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -i

ping -n 3 127.0.0.1>nul
