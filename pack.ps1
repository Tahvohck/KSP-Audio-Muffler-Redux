param(
	$Build_Dir,
	$DLL_Name,
	$Project_Name
)
cd ../..
if ( !($Build_Dir) -or !(Test-Path $Build_Dir) ) {
	Write-Error "Can't find Build_Dir, exiting."
	exit 1
}
if ( !($DLL_Name) -or !(Test-Path "$Build_Dir$DLL_Name") ) {
	Write-Error "DLL doesn't exist. Refusing to continue."
	exit 1
}
if ( !($Project_Name) ) {
	Write-Error "No project name given. Refusing to continue."
	exit 1
}

function MoveToStaging ($file, $location) {
	if (Test-Path $file) {
		Copy-Item $file $location
	} else {
		Write-Host "Unable to locate file $file"
	}
}

Write-Host "Staging files..."
$tmp = New-Item -type Dir -Force "GameData/$Project_Name/PluginData/$Project_Name"
Copy-Item "$Build_Dir$DLL_Name" "GameData/$Project_Name/"

MoveToStaging "$Build_Dir/Datafiles/LICENSE.txt"	"GameData/$Project_Name/"
MoveToStaging "$Build_Dir/Datafiles/muffler.cfg"	"GameData/$Project_Name/PluginData/$Project_Name"
MoveToStaging "$Build_Dir/Datafiles/mixer.bundle"	"GameData/$Project_Name/PluginData/$Project_Name"

Write-Host "Building zip file..."
Compress-Archive -Force "GameData" "../$Project_Name.zip"
Write-Host "Cleaning up..."
Remove-Item -Recurse "GameData"
Write-Host "Done."

#$ErrorActionPreference = $old_EAP