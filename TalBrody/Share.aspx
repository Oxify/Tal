<%@ Page Title="" Language="C#" MasterPageFile="~/Oxify.Master" AutoEventWireup="true" CodeBehind="Share.aspx.cs" Inherits="TalBrody.Share" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" />
    <link href="Css/Share.css" rel="stylesheet">

    <script type="text/javascript">
        function myPopup(url) {
            window.open(url, "myWindow", "status = 1, height = 500, width = 360, resizable = 0");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <h1>תודה שנרשמתם!</h1>
                    <h3>אנא אשרו את הרשמתכם דרך המייל שנשלח אליכם.
                        <br />
                        נשמח לעדכן אתכם על הספר ותחילת קמפיין הגיוס.
                <br />

                    </h3>
                    <h1>איך זה עובד?</h1>
                    <h3>הפיצו את הקישור הייחודי שלכם או לחצו על כפתורי השיתוף השונים.<br />
                        על כל חבר שנרשם בזכותכם לפרויקט, תצברו הנחה של 2 ש"ח שאותם תוכלו לממש בקמפיין.
                    </h3>
                    <input id="shareUrlInput" value="<%= ShareUrl %>" />
                    <div id="shareButtons">
                        <a target="_blank" href=''>
                            <div id="facebookShareButton"></div>
                        </a>
                        <a target="_blank" href='");'>
                            <div id="twitterShareButton"></div>
                        </a>
                        <a target="_blank" href=''>
                            <div id="emailShareButton"></div>
                        </a>
                    </div>
                    <div class="flat-box">
                        <div class="share-title">שתפו עם חברים</div>
                        <div class="share-buttons">
                            <a href="javascript:myPopup("<%= TwitterShareUrl %>"><span class="share-box twitter-color"><i class="fa fa-twitter "></i></span></a>
                            <div class="whatsapp-box">
                                <a href="<%= WhatsappUrl %>" data-action="share/whatsapp/share"><span class="share-box whatsapp-color"><i class="fa fa-whatsapp"></i></span></a>
                            </div>
                            <a href="mailto:?subject=Look at this cool project&body=Check out this new campaign!%0A<%= ShareUrl %>"><span class="share-box email-color"><i class="fa fa-envelope-o "></i></span>
                            </a>
                            <a href="javascript:myPopup("<%= FacebookShareUrl %>");"><span class="share-box facebook-color"><i class="fa fa-facebook"></i></span></a>

                        </div>
                    </div>
                    <div>
                        <a href="/" class="flat-button">לדף הפרוייקט</a>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
