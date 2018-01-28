@echo OFF
title gacutil regasm prompt

goto check_Permissions

:check_Permissions
    net session >nul 2>&1
    if %errorLevel% == 0 (
        REM echo Success: Administrative permissions confirmed.
        goto go
    ) else (
        echo Please run as Administrator.
    )

    pause >nul

:go

cd "CryptoTaskbar/bin/Debug"

"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\x64\gacutil.exe" /if CryptoTaskbar.dll
"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\x64\gacutil.exe" /if BandObjectLib.dll
"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\x64\gacutil.exe" /if Newtonsoft.Json.dll
"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe" CryptoTaskbar.dll
C:\Windows\System32\taskkill.exe /im explorer.exe /f
C:\Windows\explorer.exe

cd ../../..

echo Done!