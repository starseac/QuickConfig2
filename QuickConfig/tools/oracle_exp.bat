@ECHO OFF
echo ׼������{dmpdesc}���ݿ�
set backupday={backupday}

exp {user}/{password}@{datasource}  file=%backupday%/exp-{user}.dmp log=%backupday%/exp-{user}.log
echo ��������
ping -n 3 127.0.0.1>nul