<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Oxify.Master" CodeBehind="AdminDeashBord.aspx.cs" Inherits="TalBrody.AdminDeashBord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <caption>Project Table</caption>
        <asp:Repeater ID="Rpt_Project" runat="server" OnItemDataBound="Rpt_Project_ItemDataBound">
            <HeaderTemplate>
                <tr>
                    <th>#</th>
                    <th>Project Name</th>
                    <th>Project Followers</th>
                    <th>Project link</th>
                    <th>Project Edit page</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="LblCounterId" runat="server" Text="Label"></asp:Label></td>
                    <td>
                        <asp:Label ID="LblFollowers" runat="server" Text="Label"></asp:Label></td>
                    <td>>
                        <asp:HyperLink ID="HypProjectLink" runat="server">HyperLink</asp:HyperLink></td>
                    <td>
                        <asp:HyperLink ID="HypEditPojectLink" Text="Go To" runat="server"></asp:HyperLink>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
