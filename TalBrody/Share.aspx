<%@ Page Title="" Language="C#" MasterPageFile="~/Oxify.Master" AutoEventWireup="true" CodeBehind="Share.aspx.cs" Inherits="TalBrody.Share" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/Share.css" rel="stylesheet">
    
    <script type="text/javascript">
    function myPopup(url) {
        window.open(url, "myWindow", "status = 1, height = 500, width = 360, resizable = 0");
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper" id="sharepage">
	
        <div class="page-content">
	        <div class="Title">איך זה עובד?</div>
            <div class="Description">
                על כל חבר שנרשם בזכותכם לפרויקט, תצברו 2 ש"ח שאותם תוכלו לממש בקמפיין.<br/>
                הפיצו את הקישור הייחודי שלכם או לחצו על כפתורי השיתוף השונים.
            </div>
            <input id="shareUrlInput" value="<%= ShareUrl %>" />
            <div id="shareButtons">
                <a target="_blank" href='javascript:myPopup("<%= FacebookShareUrl %>");' ><div id="facebookShareButton"></div></a>
                <a target="_blank" href='javascript:myPopup("<%= TwitterShareUrl %>");' ><div id="twitterShareButton"></div></a>
                <a target="_blank" href='mailto:?subject=Look at this cool project&body=Check out this new campaign!%0A<%= ShareUrl %>' ><div id="emailShareButton"></div></a>
            </div>
        </div>
    </div>
</asp:Content>