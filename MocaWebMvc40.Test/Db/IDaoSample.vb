
Imports Moca.Db.Attr

Namespace Db

    ''' <summary>
	''' DaoSample データアクセスインタフェース
    ''' </summary>
    ''' <remarks></remarks>
    <Dao("MocaWebMvc40.Test.My.MySettings.db", GetType(Impl.DaoSample))>
    Public Interface IDaoSample

		Function GetValue() As String

    End Interface

End Namespace
