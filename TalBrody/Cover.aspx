<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Oxify.Master" CodeBehind="Cover.aspx.cs" Inherits="TalBrody.Cover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="JavaScript/Cover.js"> </script>

    <link href="Css/Cover.css" rel="stylesheet" />
    <div class="page-wrapper" id="firstpage">
        <div class="page-content">
            <div class="first-page">
                <asp:Label ID="LblTitle" runat="server" Text='השגריר' CssClass="Title"></asp:Label>
                <br />
                <asp:Label ID="Subtitle" runat="server" Text="ספרו האוטוביוגרפי של טל ברודי" CssClass="SubTitle"></asp:Label><br />
<hr/>                
                <asp:Label ID="Description" runat="server" CssClass="Description" Text='בקרוב יתחיל הקמפיין לגיוס התקציב הנחוץ להפקת ספרו האוטוביוגרפי של טל ברודי. <br/> <br/> <b>  הירשמו ותהיה הראשונים לדעת על השקת הקמפיין.</b><br/>לאחר שנרשמתם, הפיצו את הקמפיין ותצברו 2 ש"ח על כל חבר שנרשם בזכותכם<br/>לפרוייקט, אותם תוכלו לממש בקמפיין.'></asp:Label><br />
                <a class="flat-button" onclick="ShowRegister()">להרשמה</a><br/>

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
    <div class="page-wrapper">
        <div class="page-content" id="thirdpage">
            <div class="additional-page">
                עוד המון תוכן על טל ברודי
                <br />
                גם תמונות וכו'
            </div>
        </div>
    </div>

</asp:Content>
