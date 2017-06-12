@echo off 
echo 开始卸载{servicedesc}服务..... 
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe  /u {exepath}
ping -n 3 127.0.0.1>nul