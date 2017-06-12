@ECHO OFF
echo 安装并启动{servicedesc}服务
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe {exepath}
Net Start {servicename} 
ping -n 3 127.0.0.1>nul