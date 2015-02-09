﻿<%@ Page Title="Register" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TalBrody.Register" MasterPageFile="Oxify.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/Register.less" rel="stylesheet" />
    
    <h1>
        Register an account
    </h1>
    
    <input placeholder="you@email.com" id="email" runat="server" />
    <input placeholder="Your Name" id="displayName" runat="server" />
    <asp:Button ID="registerButton" runat="server" Text="Register" OnClick="registerButton_Click"  />
    
    <a href="Facebook.aspx">Sign up with Facebook</a>

</asp:Content>