<%@ Page Title="" Language="C#" MasterPageFile="~/Oxify.Master" AutoEventWireup="true" CodeBehind=" .cs" Inherits="TalBrody.Share" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" />
    <link href="/Css/Share.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron share-common">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <br />
                    <h3><strong>תודה שנרשמתם!</strong></h3>
                    <h4>אנא אשרו את הרשמתכם דרך המייל שנשלח אליכם.
                        <br />
                        נשמח לעדכן אתכם על הספר ותחילת קמפיין הגיוס.
                <br />

                    </h4>
                    <h3><strong>איך זה עובד?</strong></h3>
                    <h4>הפיצו את הקישור הייחודי שלכם או לחצו על כפתורי השיתוף השונים.<br />
                        עד לתחילת קמפיין הגיוס, באפשרותכם לצבור הנחה שאותה תוכלו לממש בקמפיין.<br />
                        <strong>על כל חבר שנרשם בזכותכם לפרויקט, תצברו הנחה של 5 ש"ח.</strong>

                    </h4>
                    <h5>שימו לב, ההנחה שצברתם תמומש בהתאם למדרגת התמיכה שתבחרו, ומותנת בתמיכה מינימלית.</h5>
                    <h4>
                        הקישור הייחודי שלכם:<br/>
                        <asp:Label ID="shareUrlInput" runat="server"></asp:Label>
                    </h4>
                    <div class="">
                        <div class="share-title h3">שתפו עם חברים</div>
                        <div class="share-buttons">
                            <a class="Popup-Link" onclick="PopupWindow();" data-target="<%= TwitterShareUrl %>"><span class="share-box twitter-color"><i class="fa fa-twitter "></i></span></a>
                            <div class="whatsapp-box">
                                <a href="<%= WhatsappUrl %>" data-action="share/whatsapp/share"><span class="share-box whatsapp-color"><i class="fa fa-whatsapp"></i></span></a>
                            </div>
                            <a href="mailto:?subject=Look at this cool project&body=Check out this new campaign!%0A<%= ShareUrl %>"><span class="share-box email-color"><i class="fa fa-envelope-o "></i></span>
                            </a>
                            <a class="Popup-Link" onclick="PopupWindow();" data-target="<%= FacebookShareUrl %> "><span class="share-box facebook-color"><i class="fa fa-facebook"></i></span></a>

                        </div>
                    </div>
                    <br />
                    <div>
                        <a href="/" class="flat-button">חזרה לדף הפרוייקט</a>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
