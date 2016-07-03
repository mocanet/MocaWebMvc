param($installPath, $toolsPath, $package, $project)

$Content = $project.ProjectItems.Item("Content")

$mocaSite = $Content.ProjectItems | where-object {$_.Name -eq "MocaSite.css"}
$mocaSite.Properties.Item("ItemType").Value = "AjaxMin"
$item = $Content.ProjectItems | where-object {$_.Name -eq "MocaSite.min.css"}
$mocaSite.ProjectItems.AddFromFile($item.Properties.Item("FullPath").Value)


$Config = $project.ProjectItems.Item("Config")

$dbConfig = $Config.ProjectItems | where-object {$_.Name -eq "db.config"}
$dbConfig.Properties.Item("BuildAction").Value = [int]0
$item = $Config.ProjectItems | where-object {$_.Name -eq "db.Debug.config"}
$item.Properties.Item("BuildAction").Value = [int]0
$dbConfig.ProjectItems.AddFromFile($item.Properties.Item("FullPath").Value)
$item = $Config.ProjectItems | where-object {$_.Name -eq "db.Hotfix.config"}
$item.Properties.Item("BuildAction").Value = [int]0
$dbConfig.ProjectItems.AddFromFile($item.Properties.Item("FullPath").Value)
$item = $Config.ProjectItems | where-object {$_.Name -eq "db.Release.config"}
$item.Properties.Item("BuildAction").Value = [int]0
$dbConfig.ProjectItems.AddFromFile($item.Properties.Item("FullPath").Value)

$log4netConfig = $Config.ProjectItems | where-object {$_.Name -eq "log4net.config"}
$log4netConfig.Properties.Item("BuildAction").Value = [int]0
$item = $Config.ProjectItems | where-object {$_.Name -eq "log4net.Debug.config"}
$item.Properties.Item("BuildAction").Value = [int]0
$log4netConfig.ProjectItems.AddFromFile($item.Properties.Item("FullPath").Value)
$item = $Config.ProjectItems | where-object {$_.Name -eq "log4net.Hotfix.config"}
$item.Properties.Item("BuildAction").Value = [int]0
$log4netConfig.ProjectItems.AddFromFile($item.Properties.Item("FullPath").Value)
$item = $Config.ProjectItems | where-object {$_.Name -eq "log4net.Release.config"}
$item.Properties.Item("BuildAction").Value = [int]0
$log4netConfig.ProjectItems.AddFromFile($item.Properties.Item("FullPath").Value)

$mocaConfig = $Config.ProjectItems | where-object {$_.Name -eq "Moca.config"}
$mocaConfig.Properties.Item("BuildAction").Value = [int]0
$item = $Config.ProjectItems | where-object {$_.Name -eq "Moca.Debug.config"}
$item.Properties.Item("BuildAction").Value = [int]0
$mocaConfig.ProjectItems.AddFromFile($item.Properties.Item("FullPath").Value)
$item = $Config.ProjectItems | where-object {$_.Name -eq "Moca.Hotfix.config"}
$item.Properties.Item("BuildAction").Value = [int]0
$mocaConfig.ProjectItems.AddFromFile($item.Properties.Item("FullPath").Value)
$item = $Config.ProjectItems | where-object {$_.Name -eq "Moca.Release.config"}
$item.Properties.Item("BuildAction").Value = [int]0
$mocaConfig.ProjectItems.AddFromFile($item.Properties.Item("FullPath").Value)

$myProject = $project.ProjectItems.Item("My Project")

$item = $myProject.ProjectItems | where-object {$_.Name -eq "AjaxMin.targets"}
$item.Properties.Item("BuildAction").Value = [int]0
$item = $myProject.ProjectItems | where-object {$_.Name -eq "Moca.targets"}
$item.Properties.Item("BuildAction").Value = [int]0

$readme = $project.ProjectItems.Item("App_Readme")

$item = $readme.ProjectItems | where-object {$_.Name -eq "Elmah.sqldb.readme.txt"}
$item.Properties.Item("BuildAction").Value = [int]0

$readmeScriptsTables = $readme.ProjectItems.Item("Scripts").ProjectItems.Item("Tables")

$item = $readmeScriptsTables.ProjectItems | where-object {$_.Name -eq "ELMAH_Error.sql"}
$item.Properties.Item("BuildAction").Value = [int]0

$readmeScriptsStored = $readme.ProjectItems.Item("Scripts").ProjectItems.Item("Stored Procedures")

$item = $readmeScriptsStored.ProjectItems | where-object {$_.Name -eq "ELMAH_GetErrorsXml.sql"}
$item.Properties.Item("BuildAction").Value = [int]0
$item = $readmeScriptsStored.ProjectItems | where-object {$_.Name -eq "ELMAH_GetErrorXml.sql"}
$item.Properties.Item("BuildAction").Value = [int]0
$item = $readmeScriptsStored.ProjectItems | where-object {$_.Name -eq "ELMAH_LogError.sql"}
$item.Properties.Item("BuildAction").Value = [int]0

$targetsFile = 'My Project\Moca.targets'

Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1

$msbuild.Xml.AddImport($targetsFile) | out-null

$project.Save()
