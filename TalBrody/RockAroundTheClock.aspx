<%@ Page Title="" Language="C#" MasterPageFile="~/Oxify.Master" AutoEventWireup="true" CodeBehind="RockAroundTheClock.aspx.cs" Inherits="TalBrody.RockAroundTheClock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/jquery.slick/1.4.1/slick.css" />
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/jquery.slick/1.4.1/slick-theme.css" />
    <link rel="stylesheet" type="text/css" href="/Css/slick-theme-oxify.css" />
    <link rel="stylesheet" href="/Css/RockAroundTheClock.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="headerbuffer"></div>
    <div class="project" id="projectpage" runat="server">
        <div class="jumbotron" id="firstpage" runat="server">
            <div class="jumbotron-header full-height-div">
                <div class="main-container">
                    <div class="container">
                        <div class="row" id="cover-page">
                            <div class="col-xs-12 col-md-10 col-md-offset-1 col-lg-8 col-lg-offset-2 margincall">
                                <div class="row main-row">
                                    <div class="col-sm-6 col-xs-12 margincall" id="title">

                                        <div class="sm-bottom-responsive sm-bottom-responsive-16by9" id="title-div">
                                            <div class="star-image hidden-xs " id="cycler" onclick="Register();">
                                                <img src="/Images/Rock/Star.png" class="star-active" onclick="Register();" />
                                                <img src="/Images/Rock/StarHover.png" onclick="Register();" />
                                            </div>
                                            <div class="sm-bottom-responsive-item" id="title-content">
                                                <h1 id="title-text"><strong>"רוק מסביב לשעון" </strong></h1>
                                                <h2 id="title-subdescription">ספר חדש מאת נעם רפפורט<br />
                                                    על תולדות הרוק העולמי</h2>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-xs-12" id="title-video">
                                        <div class="embed-responsive embed-responsive-16by9">
                                            <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/MZckMxgx6Ts?wmode=transparent&fs=1" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="visible-xs">
                                            <h3 class="Description">גיוס התקציב להפקת הספר יתחיל בימים הקרובים<br />

                                            </h3>
                                        </div>
                                        <div class="hidden-xs">
                                            <hr class="small_divider" />
                                            <h3 class="Description">גיוס התקציב להפקת הספר יתחיל בימים הקרובים<br />

                                            </h3>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="register-button-div">

                                            <a class="flat-button" id="BtnRegister" onclick="Register()">הירשמו עכשיו!</a><br />
                                            <%--                                            <a class="flat-button" href="https://www.headstart.co.il/project.aspx?id=14052">למעבר לדף הפרוייקט באתר הדסטארט</a><br />--%>
                                        </div>
                                        <h3 class="Description">על כל 10 נרשמים שתגייסו תקבלו עותק מתנה!
                                        </h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="jumbotron">
            <div class="jumbotron-header">
                <div class="main-container">
                    <div class="container">
                        <div class="row ">
                            <div class="col-xs-12 col-md-10 col-md-offset-1 col-lg-8 col-lg-offset-2">
                                <div class="row main-row" id="afterlogin" runat="server" visible="False">
                                    <div class="col-xs-12" id="secondary-title">
                                        <h2>
                                            <strong>"רוק מסביב לשעון" </strong>
                                        </h2>

                                        <h3>ספר חדש על תולדות הרוק העולמי</h3>

                                    </div>
                                    <div class="col-xs-12 col-sm-6 pull-right">
                                        <div class="embed-responsive embed-responsive-16by9">
                                            <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/MZckMxgx6Ts?wmode=transparent&fs=1" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
                                        </div>
                                    </div>
                                    <div class="col-xs-12 col-sm-6">
                                        <div id="share-and-data">
                                            <div class="flat-box flat-data blue">
                                                <div class="flat-box-right">
                                                    <div class="circle-blue ">
                                                        <div>
                                                            <i class="fa fa-ils"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="flat-box-left" runat="server" id="DiscountDiv">
                                                    <div class="flat-box-description">
                                                        צברת הנחה של
                                                    </div>
                                                    <div class="flat-box-title">
                                                        <asp:Label ID="LblDiscaount" runat="server" Text="0"></asp:Label>

                                                    </div>
                                                    <div class="flat-box-description">
                                                        ש"ח
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="flat-box flat-data grey">
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

                                            <div>
                                                <div class="coming-soon">
                                                    <div class="coming-soon-text">קמפיין הגיוס יתחיל בקרוב!
                                                    </div>
                                                </div>
                                            </div>


                                            <%-- <div class="col-xs-12 col-sm-3 ">--%>

                                            <div>
                                                <div class="flat-box">
                                                    <div class="share-title">
                                                        <h5>שתפו עם חברים</h5>
                                                    </div>
                                                </div>
                                                <div class="share-buttons">
                                                    <a class="Popup-Link" onclick="PopupWindow();" data-target="<%= TwitterShareUrl %>"><span class="share-box twitter-color"><i class="fa fa-twitter "></i></span></a>
                                                    <div class="whatsapp-box">
                                                        <a href="<%= WhatsappUrl %>" data-action="share/whatsapp/share"><span class="share-box whatsapp-color"><i class="fa fa-whatsapp"></i></span></a>
                                                    </div>
                                                    <a href="mailto:?subject=Look at this cool project&body=Check out this new campaign!%0A<%= ShareUrl %>"><span class="share-box email-color"><i class="fa fa-envelope-o "></i></span>
                                                    </a>
                                                    <a class="Popup-Link" onclick="PopupWindow();" data-target="<%= FacebookShareUrl %> "><span class="share-box facebook-color"><i class="fa fa-facebook"></i></span></a>
                                                    <a class="Copy-Link" id="CopyButton" data-clipboard-text="<%=ShareUrl %>" data-toggle="tooltip" title="העתק את הקישור היחודי ללוח" data-placement="top"><span class="share-box link-color"><i class="fa fa-clipboard"></i></span></a>

                                                </div>
                                            </div>
                                            <%--                                    </div>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="middlebuffer1"></div>
        <div class="main-row center-block">
            <div class="gallary-box">

                <div class="slick-box">
                    <a class="gallary-image" rel="gallary" href="/Images/Rock/1.jpg">
                        <img src="/Images/Rock/1A.jpg" class="thumbnail-image" />
                    </a>
                    <a class="gallary-image" rel="gallary" href="/Images/Rock/2.jpg">
                        <img src="/Images/Rock/2A.jpg" class="thumbnail-image" />
                    </a>
                    <a class="gallary-image" rel="gallary" href="/Images/Rock/3.jpg">
                        <img src="/Images/Rock/3A.jpg" class="thumbnail-image" />
                    </a>
                    <a class="gallary-image" rel="gallary" href="/Images/Rock/4.jpg">
                        <img src="/Images/Rock/4A.jpg" class="thumbnail-image" />
                    </a>
                    <a class="gallary-image" rel="gallary" href="/Images/Rock/5.jpg">
                        <img src="/Images/Rock/5A.jpg" class="thumbnail-image" />
                    </a>
                    <a class="gallary-image" rel="gallary" href="/Images/Rock/6.jpg">
                        <img src="/Images/Rock/6A.jpg" class="thumbnail-image" />
                    </a>
                </div>
            </div>
        </div>


        <div class="main-row center-block">
            <div id="disqus-div">
                <div id="disqus_thread"></div>
                <script type="text/javascript">
                    /* * * CONFIGURATION VARIABLES * * */
                    var disqus_shortname = 'oxify';
                    var disqus_identifier = '<%=ProjectId %>';
                    var disqus_title = 'עודני ילד';
                    var disqus_config = function () {
                        this.language = "he";
                    };
                    /* * * DON'T EDIT BELOW THIS LINE * * */
                    (function () {
                        var dsq = document.createElement('script'); dsq.type = 'text/javascript'; dsq.async = true;
                        dsq.src = '//' + disqus_shortname + '.disqus.com/embed.js';
                        (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
                    })();
                </script>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="//cdn.jsdelivr.net/jquery.slick/1.4.1/slick.min.js"></script>

    <script type="text/javascript" src="/JavaScript/Project.js"> </script>
</asp:Content>
