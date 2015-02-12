<%@ Page Title="Register" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TalBrody.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="JavaScript/jquery-1.8.2.min.js"></script>
    <script src="https://connect.facebook.net/en_US/all.js"></script>
    <script type="text/javascript" src="JavaScript/Register.js"> </script>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <link href="Css/Register.less" rel="stylesheet" />

            <h1>Register an account
            </h1>

            <input placeholder="you@email.com" id="email" runat="server" />
            <input placeholder="Your Name" id="displayName" runat="server" />
            <div>
                <button onclick="FaceboookLogin(); return false;">Login with FB here</button>
            </div>
            <asp:Button ID="registerButton" runat="server" Text="Register" OnClick="registerButton_Click" />

            <a href="Facebook.aspx">Sign up with Facebook</a>

            <div id="register-result">
                <asp:Label ID="registerResultLabel" runat="server" Text="Label">
            
                </asp:Label>
            </div>
            <div id="status">
            </div>

        </div>
    </form>
    <div id="fb-root"></div>
</body>
</html>
