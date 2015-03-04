<%@ Page Title="Email Confirmed" Language="C#" MasterPageFile="~/Oxify.Master" AutoEventWireup="true" CodeBehind="ConfirmEmail.aspx.cs" Inherits="TalBrody.ConfirmEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 100%">
    <script type="text/javascript">
        setTimeout(function () { window.location = "/"; }, 5000);
    </script>
    <br />
    <br />
    <br />
    <br />
    <br />
    <div style="text-align: center;">
        <h3>
            <asp:Label ID="ActionResultLabel" runat="server" Text=""></asp:Label>
        </h3>
    </div>
        
    <br />
    <br />
    <br />
    <br />
    <br />
        

    </div>
    

</asp:Content>
