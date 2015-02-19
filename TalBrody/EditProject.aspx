<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Oxify.Master" CodeBehind="EditProject.aspx.cs" Inherits="TalBrody.EditProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div>
        <asp:Label ID="Label1" runat="server" Text="Followers"></asp:Label>
        <br />
        <table>
            <asp:Repeater runat="server" ID="Rpt_Followers" OnItemDataBound="Rpt_Followers_ItemDataBound">
                <HeaderTemplate>
                    <tr>
                        <th>Id</th>
                        <th>Project ID</th>
                        <th>User ID</th>
                        <th>Create Date</th>
                        <th>Add Permission</th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="LblId" runat="server" Text="Label"></asp:Label></td>
                        <td>
                            <asp:Label ID="LblProjectId" runat="server" Text="Label"></asp:Label></td>
                        <td>
                            <asp:Label ID="LblUserId" runat="server" Text="Label"></asp:Label></td>
                        <td>
                            <asp:Label ID="LblCreateDate" runat="server" Text="Label"></asp:Label></td>
                        <td>
                            <asp:Button ID="Btn" runat="server" Text="Add Permission" OnClick="Btn_Click" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

</asp:Content>
