@ECHO OFF
echo {servicedesc}����ֹͣ��..... 
net stop {servicename}  
@echo.������ֹͣ�� 
ping -n 3 127.0.0.1>nul