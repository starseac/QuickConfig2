@ECHO OFF
echo ׼�����벻�����Ǽ����ݿ�
imp {user}/{password}@{datasource} fromuser={user} touser={user} file={dmpfile} log={impfolder}\imp-{user}.log
echo �������
ping -n 3 127.0.0.1>nul