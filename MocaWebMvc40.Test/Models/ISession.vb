﻿
Imports Moca.Web.Attr

''' <summary>
''' セッションに保存する値たち
''' </summary>
''' <remarks>
''' プロパティとして保存項目を定義してください。
''' 使うときはメンバとして定義してください。
''' </remarks>
<Session()>
Public Interface ISession

	Property AccessTime As String

End Interface
