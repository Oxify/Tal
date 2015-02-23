<%@ Page Title="" Language="C#" MasterPageFile="~/Oxify.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="TalBrody.Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Css/Project.css" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <div class="jumbotron-header">
            <div class="main-container">
                <div class="container">
                    <div class="row" id="cover-page">
                        <div class="col-xs-12 col-lg-8 col-lg-offset-2">
                            <div class="row">
                                <div class="col-sm-6 col-xs-12" id="title">
                                    <div id="title-content">
                                        <h2><strong>"עודני ילד" / חגי מרום</strong></h2>
                                        <h3>ספר חדש ונוסטלגי</h3>
                                        <h3>על "בית הבראה לצעצועים"</h3>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-xs-12" id="title-video">
                                    <div class="embed-responsive embed-responsive-16by9">
                                        <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/_urBx5_3lNY"></iframe>
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
            <div class="the-rest">
                <div class="scroll-button-wrapper">
                    <div class="scroll-button-inner">
                        <div class="scroll-button-div">
                            <a href="#" class='ScrollButton' data-goto="secondpage"></a>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>



    <div class="jumbotron">
        <div class="container-fluid ">

            <div class="row" id="second-page" style="height: 100%">
                <div class="col-md-6">
                    <h4>more things</h4>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
