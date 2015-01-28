<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="TalBrody.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

	<meta charset="utf-8" />

	<title>jQuery UI Autocomplete - Default functionality</title>

	<link rel="stylesheet" href="http://localhost:61400/code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css" />

	<script src="//code.jquery.com/jquery-1.10.2.js"></script>

	<script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>

	<link rel="stylesheet" href="/resources/demos/style.css" />

	<script>

		$(document).ready(function () {
			var Consept = $('#TxtConsept').val();
			var params = "{'Consept':'" + Consept + "'}";
			$.ajax({
				type: "POST",
				url: "MainPage.aspx/GetAutoConsept",
				async: false,
				data: params,
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (response) {
					
					var availableTags = response.d.split(",");					
					$("#TxtConsept").autocomplete({
						source: availableTags
					});
				},
				failure: function (msg) {
				}
			});
		});

	</script>


</head>
<body>
	<form id="form1" runat="server">
		<div>
			<br />
			<asp:HyperLink ID="HyperLink1" NavigateUrl="~/LogIN.aspx" runat="server">Log In</asp:HyperLink>
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<div id="ConseptIn" runat="server">
				<asp:Label ID="Label1" runat="server" Text="What do you need made?"></asp:Label><br />

				&nbsp;<asp:TextBox ID="TxtConsept" runat="server" OnTextChanged="TextBox1_TextChanged" Width="495px"></asp:TextBox>&nbsp;
				<asp:Button ID="BtnConseptIn" runat="server" OnClick="BtnConseptIn_Click" Text="Submit" />
			</div>
			<div id="EmailDiv" runat="server" visible="false">
				&nbsp;&nbsp;
				<asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:TextBox ID="TxtEmail" runat="server" Width="495px"></asp:TextBox>&nbsp; 
				<asp:Button ID="BtnEmailEnter" runat="server" OnClick="BtnEmailEnter_Click" Text="Submit" />
			</div>
		</div>
	</form>
</body>
</html>
