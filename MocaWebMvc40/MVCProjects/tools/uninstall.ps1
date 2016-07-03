param($installPath, $toolsPath, $package, $project)

# Need to load MSBuild assembly if it�fs not loaded yet.
Add-Type -AssemblyName �eMicrosoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a�f

# Grab the loaded MSBuild project for the project
$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1
$importToRemove = $msbuild.Xml.Imports | Where-Object { $_.Project.Endswith(�eMoca.targets�f) }

# Add the import and save the project
$msbuild.Xml.RemoveChild($importToRemove) | out-null

#$project = Get-Project
#$buildProject = Get-MSBuildProject
#$projectRoot = $buildProject.Xml;
#Foreach ($target in $projectRoot.Targets)
#{
#If ($target.Name -eq "WeldAfterbuild")
#{
#$projectRoot.RemoveChild($target);
#}
#}

$project.Save()
