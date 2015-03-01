<%@ Page Title="Register" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TalBrody.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/JavaScript/jquery-1.8.2.min.js"></script>
    <script src="https://connect.facebook.net/en_US/all.js"></script>
    <script type="text/javascript" src="/JavaScript/Register.js"> </script>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <h1>Register an account</h1>
            <div id="RegularResitrationDiv">
                <input placeholder="you@email.com" id="email" runat="server" />
                <input placeholder="Your Password" id="TxtPassword" type="password" runat="server" />
                <input placeholder="Your Name" id="displayName" runat="server" />

                <asp:Button ID="registerButton" runat="server" Text="Register" OnClick="registerButton_Click" />
                <hr />
                <div>
                    <button id="FacebookButton">Login with Facebook</button>
                </div>

                <div id="register-result">
                    <asp:Label ID="registerResultLabel" runat="server" Text="Label">
            
                    </asp:Label>
                </div>
                <div id="status">
                </div>
            </div>
            <div style="display:none" id="AddEmailDiv">
                <input placeholder="you@email.com" id="txtEmail" runat="server" />
                <asp:Button ID="BtnAddEmail" runat="server" Text="Add Email" OnClick="BtnAddEmail_Click" />
            </div>

        </div>
    </form>

</body>
</html>
