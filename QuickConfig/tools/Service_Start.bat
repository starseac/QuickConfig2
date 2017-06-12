@ECHO OFF
echo 启动{servicedesc}服务......  
net start {servicename} 
@echo.启动完毕！ 
ping -n 3 127.0.0.1>nul