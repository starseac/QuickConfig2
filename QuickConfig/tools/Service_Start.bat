@ECHO OFF
echo ����{servicedesc}����......  
net start {servicename} 
@echo.������ϣ� 
ping -n 3 127.0.0.1>nul