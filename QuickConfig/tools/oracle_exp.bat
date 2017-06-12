@ECHO OFF
echo 准备导出{dmpdesc}数据库
set backupday={backupday}

exp {user}/{password}@{datasource}  file=%backupday%/exp-{user}.dmp log=%backupday%/exp-{user}.log
echo 导出结束
ping -n 3 127.0.0.1>nul