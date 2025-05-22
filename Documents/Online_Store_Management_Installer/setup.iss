[Setup]
AppName=Online Store Management
AppVersion=1.0
DefaultDirName={pf}\OnlineStoreManagement
OutputDir=.
OutputBaseFilename=OnlineStoreManagement_Installer
Compression=lzma
SolidCompression=yes
PrivilegesRequired=admin

[Files]
; Main application files
Source: "OnlineStoreManagement.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "OnlineStoreManagement.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "init_db.sql"; DestDir: "{app}"; Flags: ignoreversion
Source: "OnlineStoreDB.sql"; DestDir: "{app}"; Flags: ignoreversion
Source: "setup_mysql.bat"; DestDir: "{app}"; Flags: ignoreversion
Source: "mysql-installer-community-8.0.42.0.msi"; DestDir: "{tmp}"; Flags: ignoreversion

; Required DLL files
Source: "MySql.Data.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Google.Protobuf.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZstdSharp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "BouncyCastle.Cryptography.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "FontAwesome.Sharp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "System.Diagnostics.DiagnosticSource.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "K4os.Compression.LZ4.Streams.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "K4os.Compression.LZ4.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "System.Configuration.ConfigurationManager.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "K4os.Hash.xxHash.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "System.Memory.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "System.IO.Pipelines.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "System.Runtime.CompilerServices.Unsafe.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Microsoft.Bcl.AsyncInterfaces.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "System.Buffers.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "System.Threading.Tasks.Extensions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "System.Numerics.Vectors.dll"; DestDir: "{app}"; Flags: ignoreversion

; Image resources
Source: "categories.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "OSMSlogo.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "OSMSlogo.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "review.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "customer.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "product.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "user.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "order.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "payment.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "LoginIcon.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "ForgotPasswordIcon.png"; DestDir: "{app}"; Flags: ignoreversion

[Run]
Filename: "{sys}\msiexec.exe"; Parameters: "/i ""{tmp}\mysql-installer-community-8.0.42.0.msi"" /qn /norestart"; Flags: runhidden waituntilterminated
Filename: "cmd.exe"; Parameters: "/C ""{app}\setup_mysql.bat"""; Flags: runhidden waituntilterminated
Filename: "{app}\OnlineStoreManagement.exe"; Description: "Launch Application"; Flags: nowait postinstall skipifsilent

[Icons]
Name: "{group}\Online Store Management"; Filename: "{app}\OnlineStoreManagement.exe"
