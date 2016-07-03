
Imports Moca.Di

Public Class MocaController
	Inherits System.Web.Mvc.Controller

#Region " Declare "

	''' <summary>Session Access</summary>
	Protected sessionState As ISession

	''' <summary>ViewData Model Access</summary>
	Protected model As IVDMoca

	''' <summary>Database Access</summary>
	Protected dao As Db.IDaoSample

#Region " Cookie "

	<Moca.Web.Attr.Cookie(Moca.Web.Attr.CookieType.Request)> _
	Protected cookieReq As ICookie

	<Moca.Web.Attr.Cookie(Moca.Web.Attr.CookieType.Response)> _
	Protected cookieRes As ICookie

#End Region

#Region " Logging For Log4net "
	''' <summary>Logging For Log4net</summary>
	Private Shared ReadOnly _mylog As log4net.ILog = log4net.LogManager.GetLogger(String.Empty)
#End Region
#End Region

	Function Index() As ActionResult
		Dim oldTime As String = String.Empty

		model.Title = "Index Page"
		If cookieReq.Company IsNot Nothing Then
			model.Msg = String.Format(dao.GetValue(), cookieReq.Company.Value)
		End If

		If sessionState.AccessTime Is Nothing Then
			model.Msg &= "Is New Session"
		Else
			oldTime = sessionState.AccessTime
		End If

		sessionState.AccessTime = Date.Now.ToString
		model.Msg &= String.Format(" (NowTime={0} : OldTime={1})", sessionState.AccessTime, oldTime)

		cookieRes.Company.Value = "MiYABiS"

		Return View(model)
	End Function

End Class
