<%@ Page Title="" Language="C#" MasterPageFile="~/Oxify.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="TalBrody.Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Css/Project.css" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <div class="container">
            <div class="row" id="cover-page" style="height: 100%;">
                <div class="row" style="vertical-align: bottom; background-color: lightgreen;">
                    <div class="col-md-2"></div>
                    <div class="col-md-4 col-sm-6 col-xs-12" id="title">
                        <div id="title-content">
                            <h2><strong>"עודני ילד" / חגי מרום</strong></h2>
                            <h3>ספר חדש ונוסטלגי</h3>
                            <h3>על "בית הבראה לצעצועים"</h3>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <div class="embed-responsive embed-responsive-16by9">
                            <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/_urBx5_3lNY"></iframe>
                        </div>
                    </div>
                    <div class="col-md-2"></div>
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
