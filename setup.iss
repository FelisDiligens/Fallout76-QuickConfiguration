; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Fallout 76 Quick Configuration"
#define MyAppPublisher "FelisDiligens aka. datasnake"
#define MyAppURL "https://www.nexusmods.com/fallout76/mods/546"
#define MyAppExeName "Fo76ini.exe"

#define ProjectVersion "1.11.0"
#define ProjectGitDir "D:\Workspace\Fallout 76 Quick Configuration\Fallout76-QuickConfiguration"
#define ProjectPackTargetDir "D:\Workspace\Fallout 76 Quick Configuration\Files\Main Files"

#define AppConfigDir "{localappdata}\Fallout 76 Quick Configuration"
#define INIBackupDir "{userdocs}\My Games\Fallout 76\Backups"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{997D2843-19B3-4AB4-A879-8AC56ACA26D4}
AppName={#MyAppName}
AppVersion={#ProjectVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
LicenseFile={#ProjectGitDir}\LICENSE
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputDir={#ProjectPackTargetDir}\v{#ProjectVersion}
OutputBaseFilename=Setup_v{#ProjectVersion}
SetupIconFile={#ProjectGitDir}\Fo76ini\icon.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern
DisableWelcomePage=no

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#ProjectPackTargetDir}\v{#ProjectVersion}\v{#ProjectVersion}_bin\Fo76ini.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#ProjectPackTargetDir}\v{#ProjectVersion}\v{#ProjectVersion}_bin\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

;[UninstallDelete]
;Type: filesandordirs; Name: "{#AppConfigDir}\*.*"

; https://stackoverflow.com/a/28872499
; https://stackoverflow.com/a/48153232
; https://stackoverflow.com/a/42626292
[Code]

var
  UninstallOptionsPage: TNewNotebookPage;
  UninstallNextButton: TNewButton;
  CheckBoxRemoveSettings: TNewCheckBox;
  CheckBoxRemoveBackups: TNewCheckBox;


procedure UpdateUninstallWizard;
begin
    UninstallProgressForm.PageNameLabel.Caption := 'Uninstall Fallout 76 Quick Configuration';
    UninstallProgressForm.PageDescriptionLabel.Caption :=
      'Remove Fallout 76 Quick Configuration from your computer.';

    UninstallNextButton.Caption := 'Proceed';
    UninstallNextButton.ModalResult := mrNone;

    UninstallNextButton.Caption := 'Uninstall';
    { Make the "Uninstall" button break the ShowModal loop }
    UninstallNextButton.ModalResult := mrOK;
end;  

procedure UninstallNextButtonClick(Sender: TObject);
begin
    UpdateUninstallWizard;
end;

procedure InitializeUninstallProgressForm();
var
  PageText: TNewStaticText;
  PageNameLabel: string;
  PageDescriptionLabel: string;
  CancelButtonEnabled: Boolean;
  CancelButtonModalResult: Integer;
begin
  if not UninstallSilent then
  begin
    PageNameLabel := UninstallProgressForm.PageNameLabel.Caption;
    PageDescriptionLabel := UninstallProgressForm.PageDescriptionLabel.Caption;

    { Create the Welcome page and make it active }
    UninstallOptionsPage := TNewNotebookPage.Create(UninstallProgressForm);
    UninstallOptionsPage.Notebook := UninstallProgressForm.InnerNotebook;
    UninstallOptionsPage.Parent := UninstallProgressForm.InnerNotebook;
    UninstallOptionsPage.Align := alClient;
    UninstallOptionsPage.Color := clWindow;

    UninstallProgressForm.InnerNotebook.ActivePage := UninstallOptionsPage;

    { Create controls }
    PageText := TNewStaticText.Create(UninstallProgressForm);
    with PageText do
    begin
        Parent := UninstallOptionsPage;
        Top := UninstallProgressForm.StatusLabel.Top;
        Left := UninstallProgressForm.StatusLabel.Left;
        Width := UninstallProgressForm.StatusLabel.Width;
        Height := UninstallProgressForm.StatusLabel.Height;
        AutoSize := False;
        ShowAccelChar := False;
        Caption := 'Pick optional files to remove:';
    end;


    UninstallNextButton := TNewButton.Create(UninstallProgressForm);
    with UninstallNextButton do
    begin
        Parent := UninstallProgressForm;
        Left :=
            UninstallProgressForm.CancelButton.Left -
            UninstallProgressForm.CancelButton.Width -
            ScaleX(10);
        Top := UninstallProgressForm.CancelButton.Top;
        Width := UninstallProgressForm.CancelButton.Width;
        Height := UninstallProgressForm.CancelButton.Height;
        OnClick := @UninstallNextButtonClick;
    end;

    UninstallProgressForm.CancelButton.TabOrder := UninstallNextButton.TabOrder + 1;

    CheckBoxRemoveSettings := TNewCheckBox.Create(UninstallProgressForm);
    with CheckBoxRemoveSettings do
    begin
        Parent := UninstallOptionsPage;
        Left := PageText.Left;
        Top := PageText.Top + PageText.Height;
        Width := PageText.Width;
        Height := ScaleY(30);
        Caption := 'Remove tool''s settings and log files';
        Checked := True
    end;

    CheckBoxRemoveBackups := TNewCheckBox.Create(UninstallProgressForm);
    with CheckBoxRemoveBackups do
    begin
        Parent := UninstallOptionsPage;
        Left := CheckBoxRemoveSettings.Left;
        Top := CheckBoxRemoveSettings.Top + CheckBoxRemoveSettings.Height;
        Width := CheckBoxRemoveSettings.Width;
        Height := ScaleY(30);
        Caption := 'Remove *.ini backups in "My Games" folder';
        Checked := False
    end;

    { Run our wizard pages } 
    UpdateUninstallWizard;
    CancelButtonEnabled := UninstallProgressForm.CancelButton.Enabled
    UninstallProgressForm.CancelButton.Enabled := True;
    CancelButtonModalResult := UninstallProgressForm.CancelButton.ModalResult;
    UninstallProgressForm.CancelButton.ModalResult := mrCancel;

    if UninstallProgressForm.ShowModal = mrCancel then Abort;

    { Restore the standard page payout }
    UninstallProgressForm.CancelButton.Enabled := CancelButtonEnabled;
    UninstallProgressForm.CancelButton.ModalResult := CancelButtonModalResult;

    UninstallProgressForm.PageNameLabel.Caption := PageNameLabel;
    UninstallProgressForm.PageDescriptionLabel.Caption := PageDescriptionLabel;

    UninstallProgressForm.InnerNotebook.ActivePage :=
      UninstallProgressForm.InstallingPage;
  end;
end;

procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
begin
  if CurUninstallStep = usUninstall then { or usPostUninstall }
  begin
    if CheckBoxRemoveSettings.Checked then
    begin
      Log('Deleting configuration folder');
      if DelTree(ExpandConstant('{#AppConfigDir}'), True, True, True) then
      begin
        Log('Deleted configuration folder');
      end
        else
      begin
        MsgBox('Couldn''t remove configuration folder.', mbError, MB_OK);
      end;
    end;
    if CheckBoxRemoveBackups.Checked then
    begin
      Log('Deleting backups folder');
      if DelTree(ExpandConstant('{#INIBackupDir}'), True, True, True) then
      begin
        Log('Deleted backups folder');
      end
        else
      begin
        MsgBox('Couldn''t remove backups folder.', mbError, MB_OK);
      end;
    end;
  end;
end;