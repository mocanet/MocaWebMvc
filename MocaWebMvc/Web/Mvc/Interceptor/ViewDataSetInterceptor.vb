
Imports Moca.Aop
Imports Moca.Exceptions

Namespace Web.Mvc.Interceptor

	''' <summary>
	''' ViewDataを扱うときに使用する Setter メソッドインターセプター
	''' </summary>
	''' <remarks></remarks>
	Public Class ViewDataSetInterceptor
		Inherits Web.Interceptor.AbstractHttpInterceptor
		Implements IMethodInterceptor

		''' <summary>セッション名</summary>
		Private _name As String

		''' <summary>log4net logger</summary>
		Private ReadOnly _mylog As log4net.ILog = log4net.LogManager.GetLogger(String.Empty)

#Region " コンストラクタ "

		''' <summary>
		''' コンストラクタ
		''' </summary>
		''' <param name="name">セッション名</param>
		''' <remarks></remarks>
		Public Sub New(ByVal name As String)
			_name = name
		End Sub

#End Region

		''' <summary>
		''' メソッド実行
		''' </summary>
		''' <param name="invocation">Interceptorからインターセプトされているメソッドの情報</param>
		''' <returns>該当するセッションオブジェクト</returns>
		''' <remarks>
		''' セッション名を元にセッションからオブジェクトを返す。
		''' </remarks>
		Public Function Invoke(invocation As IMethodInvocation) As Object Implements IMethodInterceptor.Invoke
			Dim contents As IHttpContents
			Dim methodName As String = invocation.This.GetType.FullName & "." & invocation.Method.Name

			checkHttpContents(invocation.This)

			contents = DirectCast(invocation.This, IHttpContents)

			_mylog.DebugFormat("(Aspect:{0}) SessionID({1}) Setter.{2}", methodName, contents.Session.SessionID, _name)

			DirectCast(contents.Target, System.Web.Mvc.Controller).ViewData(_name) = invocation.Args(0)

			Return Nothing
		End Function

	End Class

End Namespace
