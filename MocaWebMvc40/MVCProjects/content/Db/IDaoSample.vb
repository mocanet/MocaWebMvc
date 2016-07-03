
Imports Moca.Db.Attr

Namespace Db

    ''' <summary>
	''' DaoSample データアクセスインタフェース
    ''' </summary>
    ''' <remarks></remarks>
    <Dao("db", GetType(Impl.DaoSample))> _
    Public Interface IDaoSample

		Function GetValue() As String

    End Interface

End Namespace
