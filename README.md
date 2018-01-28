## C# IDeskBand2 Sample - a Media control Deskband for Windows 7+

![Screenshot](https://raw.githubusercontent.com/adrapereira/crypto-taskbar/master/screenshot.png)

Project based on source from @navhaxs ["C# IDeskBand2 Sample"](https://github.com/navhaxs/media-control-deskband). See for more details.

This builds with .NET 4.6 on Windows 10.

#### Installation steps

Edit `env.bat` and change the paths of `gacutil.exe` and `RegAsm.exe` to their installation path in your computer.
Start an elevated command prompt, then run `env.bat`.

The dll must be (re)installed into the GAC each and every time it is changed.

#### Usage

Right click the Windows taskbar, open the "Toolbars" menu and select "CryptoTaskbar".
To change between the crypto coins click the toolbar.

### Notes

`Interop.SHDocVw.dll` is generated using tlbimp.exe with the snk - on the actual SHDocVw.dll.

#### Also see

* https://github.com/dwmkerr/sharpshell/
* https://msdn.microsoft.com/en-us/library/bb762064(VS.85).aspx
