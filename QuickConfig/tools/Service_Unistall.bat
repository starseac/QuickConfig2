@echo off 
echo ��ʼж��{servicedesc}����..... 
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe  /u {exepath}
ping -n 3 127.0.0.1>nul