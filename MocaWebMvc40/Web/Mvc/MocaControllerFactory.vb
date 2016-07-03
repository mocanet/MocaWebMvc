
Imports Moca.Di

Namespace Web.Mvc

	Public Class MocaControllerFactory
		Inherits DefaultControllerFactory

		''' <summary>ページに対しての依存性注入</summary>
		Private _injector As MocaInjector

		''' <summary>
		''' 初期化処理
		''' </summary>
		''' <remarks></remarks>
		Public Shared Sub Init()
			ControllerBuilder.Current.SetControllerFactory(GetType(MocaControllerFactory))
		End Sub

		Public Sub New()
			_injector = New MocaWebMvcInjector()
		End Sub

		Public Overrides Function CreateController(requestContext As RequestContext, controllerName As String) As IController
			Dim target As IController
			target = MyBase.CreateController(requestContext, controllerName)

			' 属性による依存性の注入
			_injector.Inject(target)

			Return target
		End Function

		Public Overrides Sub ReleaseController(controller As IController)
			_injector.DaoDispose(controller)
			MyBase.ReleaseController(controller)
		End Sub

	End Class

End Namespace
