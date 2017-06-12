@echo off
echo 开始解压文件  {filename}
{7zfolder}/7-Zip/7z x {targetfile} -y -o{targetfolder}

ping -n 3 127.0.0.1>nul
