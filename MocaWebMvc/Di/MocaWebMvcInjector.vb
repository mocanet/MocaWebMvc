
Imports Moca.Attr
Imports Moca.Web.Mvc.Attr
Imports Moca.Util

Namespace Di

	''' <summary>
	''' Web API Controller に対しての依存性注入
	''' </summary>
	''' <remarks></remarks>
	Public Class MocaWebMvcInjector
		Inherits MocaWebInjector

#Region " コンストラクタ "

		''' <summary>
		''' デフォルトコンストラクタ
		''' </summary>
		''' <remarks></remarks>
		Public Sub New()
			MyBase.New()

			Me.Analyzer.Add(AttributeAnalyzerTargets.Field, New CookieAttributeAnalyzer)
			Me.Analyzer.Add(AttributeAnalyzerTargets.Field, New SessionAttributeAnalyzer)
			Me.Analyzer.Add(AttributeAnalyzerTargets.Field, New ViewDataAttributeAnalyzer)

			Me.Analyzer.FieldInject = AddressOf Me.fieldInject
		End Sub

#End Region

		''' <summary>
		''' フィールドへインスタンスの注入
		''' </summary>
		''' <param name="target">対象となるオブジェクト</param>
		''' <param name="field">対象となるフィールド</param>
		''' <param name="component">対象となるコンポーネント</param>
		''' <returns>生成したインスタンス</returns>
		''' <remarks>
		''' MocaComponent4Http として扱いたいためオーバーライド
		''' </remarks>
		Protected Shadows Function fieldInject(ByVal target As Object, ByVal field As System.Reflection.FieldInfo, ByVal component As MocaComponent) As Object
			Dim instance As Object
			Dim componentHttp As MocaComponent4HttpWebMvc

			componentHttp = TryCast(component, MocaComponent4HttpWebMvc)
			If componentHttp Is Nothing Then
				instance = component.Create()
				ClassUtil.Inject(target, field, New Object() {instance})
				Return instance
			End If

			instance = componentHttp.Create(target)
			ClassUtil.Inject(target, field, New Object() {instance})
			Return instance
		End Function

	End Class

End Namespace
