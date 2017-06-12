@ECHO OFF
echo 准备导出{dmpdesc}数据库
set backupday={backupday}
set backupdir=quickconfig_backup
set directory=QUICKCONFIG_DIR

echo 连接据库导出文件夹
net use \\{remoteIP}\c$ {remotePassword} /user:{remoteAccount}
echo 穿件临时导出文件夹
mkdir \\{remoteIP}\c$\%backupdir%

echo 在远程数据库服务器执行数据导出
expdp {user}/{password}@{datasource}  DIRECTORY=%directory% DUMPFILE=exp-{user}.dmpdp LOGFILE=exp-{user}.log SCHEMAS={user}   {excludeTable}

echo 拷贝expdp备份文件到本地
copy \\{remoteIP}\c$\%backupdir%\exp-{user}.dmpdp %backupday%\
copy \\{remoteIP}\c$\%backupdir%\exp-{user}.log %backupday%\
echo 删除临时文件
del  \\{remoteIP}\c$\%backupdir%\exp-{user}.dmpdp  /Q /F
del  \\{remoteIP}\c$\%backupdir%\exp-{user}.log  /Q /F

echo 导出结束
ping -n 3 127.0.0.1>nul