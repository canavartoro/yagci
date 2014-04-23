D:

cd "D:\Projeler\Calismalar\YAGCI_SHIPPING\\"

del /s /q *.vspscc

del /s /q /f /ah *.suo

del /s /q *.sup

del /s /q *.aps

del /s /q *.obj

del /s /q *.idb

del /s /q *.pdb

del /s /q *.exp

del /s /q *.pch

del /s /q *.pdb

del /s /q /f *.suo

del /s /q *.ncb

del /s /q *.sbr

del /s /q *.ilk

del /s /q *.bsc

del /s /q *.map

del /s /q *.pft

del /s /q *.xml

COLOR 1f

TITLE YEDEK


cd yedek

rar a -r -x*.rar -x*.xrar -x*.exe -x*\obj\* -x*\.svn* -x*.svn -x*\.git\* -x*.log -x*.pdb -ed -ep1 -agDD.MM.YYYY.HH.MM yagci_shipping- "D:\Projeler\Calismalar\YAGCI_SHIPPING\\"


SET FAIL="Dosyalar Yedeklendi " yagci_shipping9.rar 

FOR /F "tokens=1,2,3 delims=/ " %%I IN ('DATE /T') DO SET date1=%%I%%J%%K
FOR /F "tokens=1,2 delims=: " %%I IN ('TIME /T') DO SET time1=%%I:%%J
ECHO %date1% %time1%  %FAIL% >>backup.log& GOTO :EOF

pause

