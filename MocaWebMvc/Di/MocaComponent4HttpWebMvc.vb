
Imports Moca.Aop
Imports Moca.Util
Imports Moca.Web
Imports Moca.Web.Mvc

Namespace Di

	''' <summary>
	''' コンテナに格納するHttpを扱うコンポーネント
	''' </summary>
	''' <remarks></remarks>
	Public Class MocaComponent4HttpWebMvc
		Inherits MocaComponent4Http

#Region " コンストラクタ "

		''' <summary>
		''' コンストラクタ
		''' </summary>
		''' <param name="implType">実態の型</param>
		''' <param name="fieldType">フィールドの型</param>
		''' <remarks></remarks>
		Public Sub New(ByVal implType As Type, ByVal fieldType As Type)
			MyBase.New(implType, fieldType)
		End Sub

		''' <summary>
		''' コンストラクタ
		''' </summary>
		''' <param name="key">コンポーネントのキー</param>
		''' <param name="fieldType">フィールドの型</param>
		''' <remarks></remarks>
		Public Sub New(ByVal key As String, ByVal fieldType As Type)
			MyBase.New(key, fieldType)
		End Sub

#End Region

		''' <summary>
		''' オブジェクトをインスタンス化して返します。
		''' </summary>
		''' <param name="target">対象となるページ</param>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Shadows Function Create(ByVal target As Object) As Object
			If Aspects.Length = 0 Then
				Return createObject(target)
			End If
			Return createProxyObject(target)
		End Function

		''' <summary>
		''' オブジェクトをプロキシとしてインスタンス化して返します。
		''' </summary>
		''' <param name="target">対象となるページ</param>
		''' <returns></returns>
		''' <remarks>
		''' HttpContents をインスタンス化して FieldType の型に合わせてプロキシを作成してます。
		''' Webではマルチスレッドになるので、Interceptor で対象となる Page を特定する為には、
		''' 対象のセッション上の Page インスタンスが必要となる。
		''' その為、ASP上では Page を取得出来るように必ず、HttpContents を実体化することにした。
		''' </remarks>
		Protected Shadows Function createProxyObject(ByVal target As Object) As Object
			Dim val As Object = Nothing
			Dim proxy As AopProxy
			Dim typ As Type

			If TypeOf target Is System.Web.Mvc.Controller Then
				typ = GetType(HttpContentsWebMvc)
			Else
				typ = GetType(HttpContents)
			End If

			val = ClassUtil.NewInstance(typ, New Object() {target})
			proxy = New AopProxy(FieldType, Aspects, val)
			val = proxy.Create()
			Return val
		End Function

	End Class

End Namespace
