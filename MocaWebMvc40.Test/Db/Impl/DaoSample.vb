
Imports Moca.Db

Namespace Db.Impl

	''' <summary>
	''' DaoSample データアクセス
	''' </summary>
	''' <remarks></remarks>
	Public Class DaoSample
		Inherits AbstractDao
		Implements IDaoSample

		Public Function GetValue() As String Implements IDaoSample.GetValue
			Return "{0} : DaoSample Function GetValue() As String "
		End Function

	End Class

End Namespace
