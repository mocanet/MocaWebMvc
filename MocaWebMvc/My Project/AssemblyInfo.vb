﻿Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
' アセンブリに関連付けられている情報を変更するには、
' これらの属性値を変更してください。

' アセンブリ属性の値を確認します。

<Assembly: AssemblyDescription("Moca.NET Web MVC")>
<Assembly: AssemblyCompany("MiYABiS")>
<Assembly: AssemblyProduct("Moca.NET Framework")>
<Assembly: AssemblyCopyright("© MiYABiS All Rights Reserved.")>
<Assembly: AssemblyTrademark("")>

<Assembly: ComVisible(True)> 

'このプロジェクトが COM に公開される場合、次の GUID がタイプ ライブラリの ID になります。
<Assembly: Guid("f13cf433-cc78-4f8b-b784-7d8b82b2d6b2")>

' アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' すべての値を指定するか、下のように '*' を使ってビルドおよびリビジョン番号を 
' 既定値にすることができます:
' <Assembly: AssemblyVersion("1.0.*")> 

' プログラム要素が CLS (Common Language Specification) に準拠しているかどうかを示します
<Assembly: System.CLSCompliant(True)>


<Assembly: AssemblyVersion("5.0.0")>
<Assembly: AssemblyFileVersion("3.0.0")>
<Assembly: AssemblyInformationalVersion("3.0.0")>


#If net40 Then
<Assembly: AssemblyTitle("Moca.NET Web MVC .NET 4.0")>
#End If
#If net45 Then
<Assembly: AssemblyTitle("Moca.NET Web MVC .NET 4.5")>
#End If
#If net452 Then
<Assembly: AssemblyTitle("Moca.NET Web MVC .NET 4.5.2")>
#End If
#If net46 Then
<Assembly: AssemblyTitle("Moca.NET Web MVC .NET 4.6")>
#End If
#If net462 Then
<Assembly: AssemblyTitle("Moca.NET Web MVC .NET 4.6.2")>
#End If
#If net47 Then
<Assembly: AssemblyTitle("Moca.NET Web MVC .NET 4.7")>
#End If
