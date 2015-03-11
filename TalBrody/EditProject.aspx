<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Oxify.Master" CodeBehind="EditProject.aspx.cs" Inherits="TalBrody.EditProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  

    <div>
        <asp:Label ID="Label1" runat="server" Text="Followers"></asp:Label>
        <br />
        <table>
            <caption>Follower Table</caption>
            <asp:Repeater runat="server" ID="Rpt_Followers" OnItemDataBound="Rpt_Followers_ItemDataBound">
                <HeaderTemplate>
                    <tr>
                        <th class="CubeTitle_Colors rounded-corners">Id</th>
                        <th class="CubeTitle_Colors rounded-corners">Project ID</th>
                        <th class="CubeTitle_Colors rounded-corners">User ID</th>
                        <th class="CubeTitle_Colors rounded-corners">Create Date</th>
                        <th class="CubeTitle_Colors rounded-corners">Add Permission</th>
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
                            <asp:Button ID="BtnAddPermission" runat="server" Enabled="false" Text="Add Permission" OnClick="Btn_Click" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

</asp:Content>
