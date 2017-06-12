@ECHO OFF
echo {servicedesc}服务停止中..... 
net stop {servicename}  
@echo.服务已停止！ 
ping -n 3 127.0.0.1>nul