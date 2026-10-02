#define MyAppName "ParcelDesk"
#define MyAppVersion "0.2.0"
#define MyAppExeName "ParcelDesk.WinForms.exe"

[Setup]
AppId={{A73A4B83-0B69-4B23-A0B8-4C1D21EB9B63}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher=ParcelDesk

DefaultDirName={localappdata}\Programs\ParcelDesk
DefaultGroupName=ParcelDesk

PrivilegesRequired=lowest
ArchitecturesAllowed=x64compatible

DisableProgramGroupPage=yes
WizardStyle=modern

OutputDir=..\dist
OutputBaseFilename=ParcelDesk-Setup

Compression=lzma2
SolidCompression=yes

UninstallDisplayName=ParcelDesk
UninstallDisplayIcon={app}\WinForms\{#MyAppExeName}

VersionInfoVersion=0.2.0.0
VersionInfoProductName=ParcelDesk
VersionInfoProductVersion=0.2.0

SetupLogging=yes

CloseApplications=yes
RestartApplications=no

SetupIconFile=..\src\ParcelDesk.WinForms\Assets\ParcelDesk.ico

AppVerName=ParcelDesk 0.2.0

VersionInfoCompany=ParcelDesk
VersionInfoDescription=ParcelDesk Setup
VersionInfoCopyright=Copyright (c) 2026 DrX-svg
LicenseFile=..\LICENSE

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"


[Tasks]
Name: "desktopicon"; \
    Description: "Create a desktop shortcut"; \
    GroupDescription: "Additional shortcuts:"; \
    Flags: unchecked


[Files]
Source: "..\publish\WinForms\*"; \
    DestDir: "{app}\WinForms"; \
    Flags: ignoreversion recursesubdirs createallsubdirs

Source: "..\publish\Api\*"; \
    DestDir: "{app}\Api"; \
    Flags: ignoreversion recursesubdirs createallsubdirs

Source: "..\LICENSE"; \
    DestDir: "{app}"; \
    Flags: ignoreversion

Source: "..\NOTICE"; \
    DestDir: "{app}"; \
    Flags: ignoreversion

Source: "..\COMMERCIAL-LICENSING.md"; \
    DestDir: "{app}"; \
    Flags: ignoreversion

[Icons]
Name: "{group}\ParcelDesk"; \
    Filename: "{app}\WinForms\{#MyAppExeName}"

Name: "{autodesktop}\ParcelDesk"; \
    Filename: "{app}\WinForms\{#MyAppExeName}"; \
    Tasks: desktopicon


[Run]
Filename: "{app}\WinForms\{#MyAppExeName}"; \
    Description: "Launch ParcelDesk"; \
    Flags: nowait postinstall skipifsilent


[Code]

var
  RemoveAllLocalData: Boolean;


procedure StopParcelDeskProcesses;
var
  ResultCode: Integer;
begin
  Exec(
    ExpandConstant('{sys}\taskkill.exe'),
    '/F /T /IM ParcelDesk.WinForms.exe',
    '',
    SW_HIDE,
    ewWaitUntilTerminated,
    ResultCode
  );

  Exec(
    ExpandConstant('{sys}\taskkill.exe'),
    '/F /T /IM ParcelDesk.Api.exe',
    '',
    SW_HIDE,
    ewWaitUntilTerminated,
    ResultCode
  );
end;


function ShowUninstallDataChoice: Boolean;
var
  ChoiceForm: TSetupForm;
  TitleLabel: TNewStaticText;
  DescriptionLabel: TNewStaticText;
  KeepDataRadio: TNewRadioButton;
  RemoveAllRadio: TNewRadioButton;
  ContinueButton: TNewButton;
  CancelButton: TNewButton;
begin
  ChoiceForm :=
  CreateCustomForm(
    ScaleX(500),
    ScaleY(260),
    False,
    False);

  try
    ChoiceForm.Caption :=
    'Uninstall ParcelDesk';

    ChoiceForm.Position :=
    poScreenCenter;

    TitleLabel := TNewStaticText.Create(ChoiceForm);
    TitleLabel.Parent := ChoiceForm;
    TitleLabel.Left := ScaleX(24);
    TitleLabel.Top := ScaleY(20);
    TitleLabel.Width := ScaleX(450);
    TitleLabel.Caption :=
      'What should happen to your ParcelDesk data?';
    TitleLabel.Font.Style := [fsBold];

    DescriptionLabel :=
      TNewStaticText.Create(ChoiceForm);

    DescriptionLabel.Parent := ChoiceForm;
    DescriptionLabel.Left := ScaleX(24);
    DescriptionLabel.Top := ScaleY(50);
    DescriptionLabel.Width := ScaleX(450);
    DescriptionLabel.Height := ScaleY(40);
    DescriptionLabel.AutoSize := False;
    DescriptionLabel.WordWrap := True;
    DescriptionLabel.Caption :=
      'Choose whether ParcelDesk should keep your local database ' +
      'for a future installation or remove all locally stored data.';

    KeepDataRadio :=
      TNewRadioButton.Create(ChoiceForm);

    KeepDataRadio.Parent := ChoiceForm;
    KeepDataRadio.Left := ScaleX(30);
    KeepDataRadio.Top := ScaleY(105);
    KeepDataRadio.Width := ScaleX(430);
    KeepDataRadio.Caption :=
      'Keep my local database';
    KeepDataRadio.Checked := True;

    RemoveAllRadio :=
      TNewRadioButton.Create(ChoiceForm);

    RemoveAllRadio.Parent := ChoiceForm;
    RemoveAllRadio.Left := ScaleX(30);
    RemoveAllRadio.Top := ScaleY(140);
    RemoveAllRadio.Width := ScaleX(430);
    RemoveAllRadio.Caption :=
      'Remove all ParcelDesk local data';

    ContinueButton :=
      TNewButton.Create(ChoiceForm);

    ContinueButton.Parent := ChoiceForm;
    ContinueButton.Left := ScaleX(300);
    ContinueButton.Top := ScaleY(205);
    ContinueButton.Width := ScaleX(85);
    ContinueButton.Caption := 'Continue';
    ContinueButton.ModalResult := mrOk;

    CancelButton :=
      TNewButton.Create(ChoiceForm);

    CancelButton.Parent := ChoiceForm;
    CancelButton.Left := ScaleX(395);
    CancelButton.Top := ScaleY(205);
    CancelButton.Width := ScaleX(80);
    CancelButton.Caption := 'Cancel';
    CancelButton.ModalResult := mrCancel;

    ChoiceForm.ActiveControl := ContinueButton;

    Result :=
      ChoiceForm.ShowModal = mrOk;

    if Result then
      RemoveAllLocalData :=
        RemoveAllRadio.Checked;

  finally
    ChoiceForm.Free();
  end;
end;


function InitializeUninstall: Boolean;
begin
  Result :=
    ShowUninstallDataChoice;
end;


procedure CurUninstallStepChanged(
  CurUninstallStep: TUninstallStep);
var
  UserDataDirectory: String;
begin
  UserDataDirectory :=
    ExpandConstant(
      '{localappdata}\ParcelDesk');

  if CurUninstallStep = usUninstall then
  begin
    StopParcelDeskProcesses;
  end;

  if CurUninstallStep = usPostUninstall then
  begin
    if RemoveAllLocalData then
    begin
      DelTree(
        UserDataDirectory,
        True,
        True,
        True
      );
    end
    else
    begin
      DeleteFile(
        UserDataDirectory +
        '\client-settings.json'
      );

      DeleteFile(
        UserDataDirectory +
        '\secure-db-config.dat'
      );

      DeleteFile(
        UserDataDirectory +
        '\shipment-grid-columns.json'
      );
    end;
  end;
end;