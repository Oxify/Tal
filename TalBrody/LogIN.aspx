<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIN.aspx.cs" Inherits="fblogin.LogIN" %>
<%@ Register TagPrefix="rp" Namespace="DotNetOpenAuth.OpenId.RelyingParty" Assembly="DotNetOpenAuth.OpenId.RelyingParty.UI, Version=4.3.0.0, Culture=neutral, PublicKeyToken=2780ccd10d57b246" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
		<script src="//code.jquery.com/jquery-1.10.2.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left:500px;margin-top:150px">
        
        
        <asp:Label ID="Label1" runat="server" Text="OpenID Login" />
        <asp:TextBox ID="openIdBox" runat="server" />
        <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" />
        <asp:CustomValidator runat="server" ID="openidValidator" ErrorMessage="Invalid OpenID Identifier"
            ControlToValidate="openIdBox" EnableViewState="false" OnServerValidate="openidValidator_ServerValidate" />
        <br />
        <asp:Label ID="loginFailedLabel" runat="server" EnableViewState="False" Text="Login failed"
                Visible="False" />
        <asp:Label ID="loginCanceledLabel" runat="server" EnableViewState="False" Text="Login canceled"
                Visible="False" />


        <h1>Login with</h1>
        <ul>
            <li>Google</li>
            <li>Facebook</li>
        </ul>

        <rp:OpenIdLogin ID="OpenIdLogin1" runat="server" />

        <br/>
        <br/>
		<asp:Login ID="Login1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" Height="155px" Width="239px" OnAuthenticate="Login1_Authenticate">
			<InstructionTextStyle Font-Italic="True" ForeColor="Black" />
			<LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
			<TextBoxStyle Font-Size="0.8em" />
			<TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
		</asp:Login>
        <br />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
