!define COMPANYNAME "Zehner Software"
!define SOFTWARENAME "Music Library Editor"

;--------------------------------

; The name of the installer
Name "Music Library Editor"

; The file to write
OutFile "Music Library Editor.exe"

; The default installation directory
InstallDir "$PROGRAMFILES\${COMPANYNAME}\${SOFTWARENAME}"

; Request application privileges for Windows Vista
RequestExecutionLevel admin

;--------------------------------

; Pages

Page components
Page directory
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------

; The stuff to install
Section "Music Library Editor (required)" ;No components page, name is not important

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File "MusicLibraryEditor\bin\Debug\MusicLibraryEditor.exe"
  File "MusicLibraryEditor\bin\Debug\taglib-sharp.dll"
  File "MusicLibraryEditor\bin\Debug\Hqub.MusicBrainze.API.dll"
  File "MusicLibraryEditor\bin\Debug\noart.png"
  
  ; Write the installation path into the registry
  WriteRegStr HKLM SOFTWARE\MusicLibraryEditor "Install_Dir" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\MusicLibraryEditor" "DisplayName" "MusicLibraryEditor"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\MusicLibraryEditor" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\MusicLibraryEditor" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\MusicLibraryEditor" "NoRepair" 1
  WriteUninstaller "uninstall.exe"
  
  createDirectory "$SMPROGRAMS\${COMPANYNAME}"
  createShortCut "$SMPROGRAMS\${COMPANYNAME}\${SOFTWARENAME}.lnk" "$INSTDIR\MusicLibraryEditor.exe" "" ""
  
SectionEnd ; end the section


; Uninstaller

Section "Uninstall"
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\MusicLibraryEditor"
  DeleteRegKey HKLM SOFTWARE\MusicLibraryEditor

  ; Remove files and uninstaller
  Delete $INSTDIR\MusicLibraryEditor.exe
  Delete $INSTDIR\taglib-sharp.dll
  Delete $INSTDIR\Hqub.MusicBrainze.API.dll
  Delete $INSTDIR\noart.png
  Delete $INSTDIR\uninstall.exe

  ; Remove shortcuts, if any
  Delete "$SMPROGRAMS\${COMPANYNAME}\*.*"

  ; Remove directories used
  RMDir "$SMPROGRAMS\${COMPANYNAME}"
  RMDir "$INSTDIR"
  RMDir "$PROGRAMFILES\${COMPANYNAME}"

SectionEnd