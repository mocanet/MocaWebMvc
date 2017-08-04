
Imports System.Reflection
Imports System.Web.Mvc

Namespace Web.Mvc

	''' <summary>
	''' Http時のインタセプターで使用するMvcControllerコンテンツ
	''' </summary>
	''' <remarks></remarks>
	Public Class HttpContentsWebMvc
		Inherits MarshalByRefObject
		Implements IHttpContents

		Private _target As Controller

		Private _queryStringMap As Hashtable

#Region " コンストラクタ "

		''' <summary>
		''' コンストラクタ
		''' </summary>
		''' <param name="target">Controller</param>
		''' <remarks></remarks>
		Public Sub New(ByVal target As Controller)
			_target = target
			_queryStringMap = New Hashtable
		End Sub

#End Region

#Region " Implements "

		Public ReadOnly Property Application As HttpApplicationState Implements IHttpContents.Application
			Get
				Return _target.HttpContext.ApplicationInstance.Application
			End Get
		End Property

		Public ReadOnly Property QueryStringMap As Hashtable Implements IHttpContents.QueryStringMap
			Get
				Return _queryStringMap
			End Get
		End Property

		Public ReadOnly Property Request As HttpRequest Implements IHttpContents.Request
			Get
				Return _target.HttpContext.ApplicationInstance.Request
			End Get
		End Property

		Public ReadOnly Property Response As HttpResponse Implements IHttpContents.Response
			Get
				Return _target.HttpContext.ApplicationInstance.Response
			End Get
		End Property

		Public ReadOnly Property Session As HttpSessionState Implements IHttpContents.Session
			Get
				Return _target.HttpContext.ApplicationInstance.Session
			End Get
		End Property

		Public ReadOnly Property Target As Object Implements IHttpContents.Target
			Get
				Return _target
			End Get
		End Property

#End Region

	End Class

End Namespace
