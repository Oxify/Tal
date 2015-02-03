<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Oxify.Master" CodeBehind="Cover.aspx.cs" Inherits="TalBrody.Cover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="JavaScript/Cover.js"> </script>

    <link href="Css/Cover.css" rel="stylesheet" />
    <div class="page-wrapper" id="firstpage">
        <div class="page-content">
            <div class="first-page">
                <asp:Label ID="LblTitle" runat="server" Text='"השגריר"' Font-Size="60px" Font-Bold="True"></asp:Label>
                <br />
                <asp:Label ID="Subtitle" runat="server" Text="ספרו האוטוביוגרפי של טל ברודי" Font-Size="50px"></asp:Label><br />
                <asp:Button CssClass="flat-button" ID="BtnSignup" runat="server" Text="להרשמה" /><br />
                <asp:Label ID="Description" runat="server" Font-Size="30px" Text="בקרוב יתחיל הקמפיין לגיוס התקציב הנחוץ להפקת ספרו האוטוביוגרפי של טל ברודי <br/> <b>  הירשמו, הפיצו את הקישור כבר עכשיו ותזכו להנחות והטבות  </b>
                     "></asp:Label><br />

            </div>

            <div class="scroll-button-wrapper">
                <br />
                <br />
                <br />

                <a href="#" class='ScrollButton' id="ScrollDown" data-goto="secondpage"></a>
            <br />
            </div>
        </div>

    </div>
    <div class="page-wrapper">
        <div class="page-content" id="secondpage">
            <div class="additional-page">
                עוד המון תוכן על טל ברודי
                <br />
                גם תמונות וכו'
            </div>
        </div>
    </div>
</asp:Content>
