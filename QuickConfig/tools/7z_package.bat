@echo off
echo 开始压缩文件  {filename}
{7zfolder}\7-Zip\7z a  {target} {orifolder}{FolderOrFile}   {excludeFolder}   {excludeFile}   

ping -n 3 127.0.0.1>nul
