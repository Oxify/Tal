<%@ Page Title="" Language="C#" MasterPageFile="~/Oxify.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="TalBrody.Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ShowRegister() {

            var ProjectId = 1;

            var href = "Register.aspx?ProjectId=" + ProjectId;

            var txtSaveClickedHidden = '';
            var a = $(".BtnRegister").val;
            $(".BtnRegister").fancybox(
            {
                maxWidth: 516,
                maxHeight: 520,
                fitToView: false,
                width: '80%',
                height: '95%',
                autoSize: false,
                closeClick: false,
                openEffect: 'none',
                closeEffect: 'none',
                nextEffect: 'fade',
                prevEffect: 'fade',
                'href': href,
                'type': 'iframe',

                //Change title position and overlay color
                helpers:
                {
                    title:
                    {
                        type: 'inside',
                        position: 'top',
                        background: '#032f4a',
                        color: '#FFF'
                    }
                },
                beforeClose: function () {
                    //txtSaveClickedHidden = $('.fancybox-iframe').contents().find("#txtSaveClickedHidden").val();
                },
                afterClose: function () {
                    //if (true) {
                    //parent.location.reload(true);
                    //}
                }
            });

        }
    </script>
    <link rel="stylesheet" href="Css/Project.css" type="text/css" />
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/jquery.slick/1.4.1/slick.css" />
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/jquery.slick/1.4.1/slick-theme.css" />
    <link rel="stylesheet" type="text/css" href="Css/slick-theme-oxify.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="project" id="projectpage" runat="server">
        <div class="jumbotron" id="firstpage">
            <div class="jumbotron-header">
                <div class="main-container">
                    <div class="container">
                        <div class="row" id="cover-page">
                            <div class="col-xs-12 col-md-10 col-md-offset-1 col-lg-8 col-lg-offset-2">
                                <div class="row main-row">
                                    <div class="col-sm-6 col-xs-12" id="title">
                                        <div class="sm-bottom-responsive sm-bottom-responsive-16by9" id="title-div">
                                            <div class="sm-bottom-responsive-item" id="title-content">
                                                <h2><strong>"עודני ילד" </strong></h2>
                                                <h3>ספר נוסטלגי
                                                <br />
                                                    על "בית הבראה לצעצועים"</h3>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-xs-12" id="title-video">
                                        <div class="embed-responsive embed-responsive-16by9">
                                            <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/2xgVbFniiVU?wmode=transparent&showinfo=0&fs=1" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="visible-xs">

                                            <h3 class="Description">בקרוב נתחיל לגייס את התקציב הנחוץ להפקת הספר.
					
                                            <b>הירשמו ותוכלו לזכות בהטבות מיוחדות.</b>
                                                ביחד, נוציא את הספר לאור.
                                            </h3>
                                        </div>
                                        <div class="hidden-xs">
                                            <hr class="small_divider" />
                                            <h3 class="Description">בקרוב נתחיל לגייס את התקציב הנחוץ להפקת הספר.
					<br />
                                                <b>הירשמו ותוכלו לזכות בהטבות מיוחדות.</b><br />
                                                ביחד, נוציא את הספר לאור.
                                            </h3>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="register-button-div">
                                            <a class="flat-button BtnRegister fancybox.iframe" id="BtnRegister" onclick="ShowRegister()">הירשמו עכשיו</a><br />
                                        </div>
                                        <div class="scroll-icon-wrapper">
                                            <a href="#" class='scroll-icon' data-goto="secondpage"><i class="fa fa-arrow-circle-down"></i></a>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="jumbotron" id="secondpage">
            <div class="jumbotron-header">
                <div class="main-container">
                    <div class="container">
                        <div class="row ">
                            <div class="col-xs-12 col-md-10 col-md-offset-1 col-lg-8 col-lg-offset-2">
                                <div class="row main-row">
                                    <div class="col-sm-6 col-xs-12">
                                        <h2><strong>"עודני ילד" / חגי מרום</strong></h2>
                                        <h3>הספר על "בית ההבראה לצעצועים"</h3>
                                        <h4>"עודני ילד" הוא ספר חדש מאת חגי מרום.
                                                <br />
                                            הספר מכיל כ-250 צילומי צעצועים ומשחקים ישנים. אשר נבחרו בקפידה מתוך האוסף הפרטי של בני וג'ניס ירוחם, שהקימו לפני כשנתיים את "בית הבראה לצעצועים" - מוזיאון צעצועים ללא כוונות רווח, הממוקם בנמל יפו.<br />
                                            הספר נותן פרספקטיבה רחבה ומגוונת על צעצועי ומשחקי הילדות בארץ, החל משנות ה-50 ועד שנות ה-80.<br />
                                            בספר 20 פרקים, ובתחילת כל פרק שיר ילדים עם ברקוד לסריקה שיוביל לקישור ביוטיוב ובו קליפ עם השיר שצולם במיוחד לספר.</h4>
                                        <br />
                                    </div>
                                    <div class="col-sm-6 col-xs-12">
                                        <div class="embed-responsive embed-responsive-16by9">
                                            <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/2xgVbFniiVU?wmode=transparent&showinfo=0&fs=1" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
                                        </div>
                                        <div>
                                            <div class="coming-soon">
                                                <div class="coming-soon-text">הקמפיין יתחיל בשבועות הקרובים</div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-12 col-sm-6">
                                                <div class="flat-box blue">
                                                    <div class="flat-box-right">
                                                        <div class="circle-blue ">
                                                            <div>
                                                                <i class="fa fa-ils"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="flat-box-left" runat="server" id="DiscountDiv">
                                                        <div class="flat-box-title">
                                                            <asp:Label ID="LblDiscaount" runat="server" Text="0"></asp:Label>
                                                            ש"ח
                                                        </div>
                                                        <div class="flat-box-description">
                                                            הנחה צברת
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="flat-box grey">
                                                    <div class="flat-box-right">
                                                        <div class="circle-grey ">
                                                            <div>
                                                                <i class="fa fa-male"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="flat-box-left">
                                                        <div class="flat-box-title">
                                                            <asp:Label ID="LblFollowerCount" runat="server" Text="0"></asp:Label>
                                                        </div>
                                                        <div class="flat-box-description">
                                                            עוקבים אחר הפרוייקט
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <div class="flat-box">
                                                    <div class="share-title">
                                                        <h3>שתפו עם חברים</h3>
                                                    </div>
                                                    <div class="share-buttons">
                                                        <a href="twitter sharer"><span class="share-box twitter-color"><i class="fa fa-twitter "></i></span></a>
                                                        <div class="whatsapp-box">
                                                            <a href="whatsapp://send?text=oxify.co/code" data-action="share/whatsapp/share"><span class="share-box whatsapp-color"><i class="fa fa-whatsapp"></i></span></a>
                                                        </div>
                                                        <br />
                                                        <a href="mailto:..."><span class="share-box email-color"><i class="fa fa-envelope-o "></i></span>
                                                        </a>
                                                        <a href="facebook sharer"><span class="share-box facebook-color"><i class="fa fa-facebook"></i></span></a>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </div>
                            </div>
                            <div class="col-xs-12 col-md-10 col-md-offset-1 col-lg-8 col-lg-offset-2">
                            </div>
                            <div class="col-xs-12 col-md-10 col-md-offset-1 col-lg-8 col-lg-offset-2">

                                <div class="row main-row">
                                    <div class="col-xs-2">
                                        צרו איתנו קשר
                                                <div class="info-buttons" style="margin-right: -1px;">
                                                    <a href="mailto:hagi@hagimarom.com"><span class="share-box email-color"><i class="fa fa-envelope-o "></i></span>
                                                    </a>
                                                </div>
                                        <div class="info-buttons">
                                            <a href="https://www.facebook.com/ChildhoodMuseum"><span class="share-box facebook-color"><i class="fa fa-facebook"></i></span></a>
                                        </div>
                                    </div>
                                    <div class="col-xs-8">
                                        <h3>הפרוייקט של חגי מרום ובני ירוחם</h3>
                                    </div>
                                    <div class="col-sm-2 col-xs-12">
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <img src="Images/Toys/BennyAndHagi.jpg" width="150px" height="90px" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="row main-row">
                                    <h4>
                                        <strong>חגי מרום</strong> - אספן תרבות ישראלית, מעצב גרפי וצלם, הקים בשנת 2011 את הוצאת הספרים "מרום
תרבות ישראלית". ההוצאה מפיקה ומוציאה לאור ספרים העוסקים בתרבות , אמנות ונוסטלגיה
ישראלית.
                                <br />
                                        <strong>בני ירוחם</strong>
                                        - אספן צעצועים ומשחקים ישנים, הקים בשנת 2011 ביחד עם ג'ניס אישתו, את "בית
הבראה לצעצועים", מוזיאון צעצועים ללא כוונת רווח, הפועל בנמל יפו. שיתוף הפעולה בין חגי ובני
נוצר מתוך כבוד ואהבה משותפים לנוסטלגיה הישראלית ומתוך כוונה לשמר ולתעד אותה.</h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />

        </div>
        <div class="gallary-box ">

            <div class="slick-box">
                <a class="gallary-image" rel="gallary" href="/Images/Toys/1.jpg">
                    <img src="/Images/Toys/1A.jpg" />
                </a>
                <a class="gallary-image" rel="gallary" href="/Images/Toys/2.jpg">
                    <img src="/Images/Toys/2A.jpg" />
                </a>
                <a class="gallary-image" rel="gallary" href="/Images/Toys/3.jpg">
                    <img src="/Images/Toys/3A.jpg" />
                </a>
                <a class="gallary-image" rel="gallary" href="/Images/Toys/4.jpg">
                    <img src="/Images/Toys/4A.jpg" />
                </a>
                <a class="gallary-image" rel="gallary" href="/Images/Toys/5.jpg">
                    <img src="/Images/Toys/5A.jpg" />
                </a>
                <a class="gallary-image" rel="gallary" href="/Images/Toys/6.jpg">
                    <img src="/Images/Toys/6A.jpg" />
                </a>
            </div>
        </div>

    </div>
    <script type="text/javascript" src="//cdn.jsdelivr.net/jquery.slick/1.4.1/slick.min.js"></script>

    <script type="text/javascript" src="JavaScript/Project.js"> </script>

</asp:Content>
