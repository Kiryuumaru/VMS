@ECHO OFF
REM BFCPEOPTIONSTART
REM Advanced BAT to EXE Converter www.BatToExeConverter.com
REM BFCPEEXE=C:\Users\Kiryuumaru\Repositories\VMS\VMS.exe
REM BFCPEICON=C:\Program Files (x86)\Advanced BAT to EXE Converter v4.11\ab2econv411\icons\icon1.ico
REM BFCPEICONINDEX=1
REM BFCPEEMBEDDISPLAY=0
REM BFCPEEMBEDDELETE=0
REM BFCPEADMINEXE=0
REM BFCPEINVISEXE=1
REM BFCPEVERINCLUDE=0
REM BFCPEVERVERSION=1.0.0.0
REM BFCPEVERPRODUCT=Product Name
REM BFCPEVERDESC=Product Description
REM BFCPEVERCOMPANY=Your Company
REM BFCPEVERCOPYRIGHT=Copyright Info
REM BFCPEEMBED=C:\Users\Kiryuumaru\Repositories\VMS\VMS\bin\x86\Release\VMS.exe
REM BFCPEOPTIONEND
@ECHO ON
mkdir Bin
move %MYFILES%\VMS.exe %CD%\Bin\VMS.exe
cd Bin
VMS.exe
