<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width" />
	<title>@ViewData("Title")</title>
	<link href="@Url.Content("~/Content/MocaSite.css")" rel="stylesheet" type="text/css" />
	@Scripts.Render("~/bundles/modernizr")
</head>
<body>
	<a id="PageTop"></a>
	<div class="main">
		<div class="contents">
			<form id="frmMain" runat="server">
				<h1>Project Title</h1>
				<div class="container">
					@RenderBody()
				</div>
				<div id="footer" class="footer">
				</div>
			</form>
		</div>
	</div>
	<div class="background">
	</div>

	@Scripts.Render("~/bundles/jquery")
	@RenderSection("scripts", required:=False)
</body>
</html>
