<%@ Page Title="" Language="C#" MasterPageFile="~/Oxify.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="TalBrody.Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Css/Project.css" type="text/css" />
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <div class="jumbotron-header">
            <div class="main-container">
                <div class="container">
                    <div class="row" id="cover-page">
                        <div class="col-xs-12 col-md-10 col-md-offset-1 col-lg-8 col-lg-offset-2">
                            <div class="row main-row">
                                <div class="col-sm-6 col-xs-12" id="title">
                                    <div class="sm-bottom-responsive sm-bottom-responsive-16by9" id="title-div">
                                        <div class="sm-bottom-responsive-item" id="title-content">
                                            <h2><strong>"עודני ילד" / חגי מרום</strong></h2>
                                            <h3>ספר חדש ונוסטלגי
                                                <br />
                                                על "בית הבראה לצעצועים"</h3>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-xs-12" id="title-video">
                                    <div class="embed-responsive embed-responsive-16by9">
                                        <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/_urBx5_3lNY?wmode=transparent"></iframe>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <hr class="small_divider" />
                                    <h4 class="Description">בקרוב יתחיל הקמפיין לגיוס התקציב הנחוץ להפקת הספר.
					<br />
                                        <b>הירשמו ותהיה הראשונים לדעת על השקת הקמפיין.</b><br />
                                        לאחר שנרשמתם, הפיצו את הקמפיין ותצברו 2 ש"ח על כל חבר שנרשם בזכותכם<br />
                                        לפרוייקט, אותם תוכלו לממש בקמפיין.
                                    </h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="register-button-div">
                                        <a class="flat-button" id="BtnRegister" onclick="ShowRegister()">להרשמה</a><br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="buffer"></div>
            <div class="the-rest">
                <div class="scroll-button-wrapper">
                    <div class="scroll-button-inner">
                        <div class="scroll-button-div">
                            <a href="#" class='ScrollButton' data-goto="secondpage"></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="last-row"></div>
        </div>
    </div>



    <div class="jumbotron" id="secondpage">
        <div class="jumbotron-header">
            <div class="main-container">
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12 col-md-10 col-md-offset-1 col-lg-8 col-lg-offset-2">
                            <div class="row main-row">
                                <div class="col-sm-6 col-xs-12">
                                    <div>
                                        <div>
                                            <h2><strong>"עודני ילד" / חגי מרום</strong></h2>
                                            <h3>הספר על "בית ההבראה לצעצועים"</h3>
                                            <h4>"עודני ילד" הוא ספר חדש מאת חגי מרום.
                                                <br />
                                                הספר מכיל כ-250 צילומי צעצועים ומשחקים ישנים. אשר נבחרו בקפידה מתוך האוסף הפרטי של בני וג'ניס ירוחם, שהקימו לפני כשנתיים את "בית הבראה לצעצועים" - מוזיאון צעצועים ללא כוונות רווח, הממוקם בנמל יפו.<br />
                                                הספר נותן פרספקטיבה רחבה ומגוונת על צעצועי ומשחקי הילדות בארץ, החל משנות ה-50 ועד שנות ה-80.<br />
                                                בספר 20 פרקים, ובתחילת כל פרק שיר ילדים עם ברקוד שיוביל לקישור ביוטיוב ובו קליפ עם השיר שצולם במיוחד לספר.</h4>
                                            <br />
                                        </div>


                                    </div>
                                </div>
                                <div class="col-sm-6 col-xs-12">
                                    <div class="embed-responsive embed-responsive-16by9">
                                        <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/_urBx5_3lNY?wmode=transparent"></iframe>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-sm-4 col-xs-6">
                                    <div class="flat-box blue">
                                        <div class="flat-box-right">
                                            <div class="circle-blue ">
                                                <div>
                                                    <i class="fa fa-money"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="flat-box-left">
                                            <div class="flat-box-title">
                                                22 ש"ח
                                            </div>
                                            <div class="flat-box-description">
                                                הנחה צברת
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4 col-xs-6">
                                    <div class="flat-box grey">
                                        <div class="flat-box-right">
                                            <div class="circle-grey ">
                                                <div>
                                                    <i class="fa fa-users"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="flat-box-left">
                                            <div class="flat-box-title">
                                                188
                                            </div>
                                            <div class="flat-box-description">
                                                עוקבים אחר הפרוייקט
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4 col-xs-6">
                                    <div class="flat-box">
                                        <div class="share-title">שתפו עם חברים</div>
                                        <div class="share-buttons">
                                            <div class="share-box"><i class="fa fa-facebook facebook-color"></i></div>
                                            <div class="share-box"><i class="fa fa-twitter twitter-color"></i></div>
                                            <%--                                        <div class="share-box">
                                            <a href="https://twitter.com/share" class="twitter-share-button" data-url="http://www.oxify.co/test" data-size="large" data-count="vertical">צייץ</a>
                                            <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
                                        </div>--%>
                                            <div class="share-box whatsapp-box"><a href="whatsapp://send?text=oxify.co/code" data-action="share/whatsapp/share"><i class="fa fa-whatsapp whatsapp-color"></i></a></div>
                                            <div class="share-box"><i class="fa fa-envelope-o email-color"></i></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="buffer"></div>
            <div class="the-rest">
                <div class="scroll-button-wrapper">
                    <div class="scroll-button-inner">
                        <div class="scroll-button-div">
                            <a href="#" class='ScrollButton' data-goto="thirdpage"></a>
                        </div>
                    </div>
                </div>

            </div>
            <div class="last-row"></div>

        </div>
    </div>
    <div class="jumbotron" id="thirdpage">
        <div class="jumbotron-header">
            <div class="main-container">
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12 col-md-10 col-md-offset-1 col-lg-8 col-lg-offset-2">
                            <div class="row main-row">
                                <div class="col-sm-6 col-xs-12">
                                    <div class="sm-bottom-responsive sm-bottom-responsive-16by9">
                                        <div class="sm-bottom-responsive-item">
                                            <h2><strong>"עודני ילד" / חגי מרום</strong></h2>
                                            <h3>ספר חדש ונוסטלגי
                                                <br />
                                                על "בית הבראה לצעצועים"</h3>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-xs-12">
                                    <div class="embed-responsive embed-responsive-16by9">
                                        <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/_urBx5_3lNY?wmode=transparent"></iframe>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <hr class="small_divider" />
                                    <h4 class="Description">בקרוב יתחיל הקמפיין לגיוס התקציב הנחוץ להפקת הספר.
					<br />
                                        <b>הירשמו ותהיה הראשונים לדעת על השקת הקמפיין.</b><br />
                                        לאחר שנרשמתם, הפיצו את הקמפיין ותצברו 2 ש"ח על כל חבר שנרשם בזכותכם<br />
                                        לפרוייקט, אותם תוכלו לממש בקמפיין.
                                    </h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="register-button-div">
                                        <a class="flat-button" id="BtnRegister" onclick="ShowRegister()">להרשמה</a><br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="buffer"></div>
            <div class="the-rest">
            </div>
        </div>
    </div>

    <script type="text/javascript" src="JavaScript/Cover.js"> </script>
</asp:Content>
