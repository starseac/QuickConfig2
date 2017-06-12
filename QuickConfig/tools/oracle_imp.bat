@ECHO OFF
echo 准备导入不动产登记数据库
imp {user}/{password}@{datasource} fromuser={user} touser={user} file={dmpfile} log={impfolder}\imp-{user}.log
echo 导入结束
ping -n 3 127.0.0.1>nul