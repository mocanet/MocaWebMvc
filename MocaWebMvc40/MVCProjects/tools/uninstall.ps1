param($installPath, $toolsPath, $package, $project)

# Need to load MSBuild assembly if itÅfs not loaded yet.
Add-Type -AssemblyName ÅeMicrosoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aÅf

# Grab the loaded MSBuild project for the project
$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1
$importToRemove = $msbuild.Xml.Imports | Where-Object { $_.Project.Endswith(ÅeMoca.targetsÅf) }

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
