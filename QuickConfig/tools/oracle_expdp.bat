@ECHO OFF
echo ׼������{dmpdesc}���ݿ�
set backupday={backupday}
set backupdir=quickconfig_backup
set directory=QUICKCONFIG_DIR

echo ���Ӿݿ⵼���ļ���
net use \\{remoteIP}\c$ {remotePassword} /user:{remoteAccount}
echo ������ʱ�����ļ���
mkdir \\{remoteIP}\c$\%backupdir%

echo ��Զ�����ݿ������ִ�����ݵ���
expdp {user}/{password}@{datasource}  DIRECTORY=%directory% DUMPFILE=exp-{user}.dmpdp LOGFILE=exp-{user}.log SCHEMAS={user}   {excludeTable}

echo ����expdp�����ļ�������
copy \\{remoteIP}\c$\%backupdir%\exp-{user}.dmpdp %backupday%\
copy \\{remoteIP}\c$\%backupdir%\exp-{user}.log %backupday%\
echo ɾ����ʱ�ļ�
del  \\{remoteIP}\c$\%backupdir%\exp-{user}.dmpdp  /Q /F
del  \\{remoteIP}\c$\%backupdir%\exp-{user}.log  /Q /F

echo ��������
ping -n 3 127.0.0.1>nul