<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Oxify.Master" CodeBehind="EmailCenter.aspx.cs" Inherits="TalBrody.EmailCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div>
        <asp:Label ID="LblFollo" runat="server" Text="Followers To send email"></asp:Label>
        <div>
            <script src="Scripts/tinymce/tinymce.js"></script>
            <script src="Scripts/tinymce/TinymceInit.js"></script>
            <textarea rows="20" cols="20" id="txtSystemEmailInfoFooter" class="tinymce" name="content" style="width: 800px; height: 400px" runat="server"></textarea>
        </div>
        <br />
        <div>
            <asp:Label ID="Label1" runat="server" Text="Email Subject"></asp:Label><asp:TextBox placeholder="Email Subject" ID="TxtSubject" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Email From"></asp:Label><asp:TextBox placeholder="Sample@sample.com" ID="TxtEmailFrom" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="From Name"></asp:Label><asp:TextBox placeholder="Sample Name" ID="TxtFromName" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="BtnSendEmails" runat="server" Text="Send Email" OnClick="BtnSendEmail_Click" />
            <input type="submit" id="BtnSubmit" value="send email" runat="server" onclick="BtnSendEmail_Click" />
        </div>
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
                        <th class="CubeTitle_Colors rounded-corners">Send Mail</th>
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
                            <asp:CheckBox ID="CBSendEmail" Checked="true" runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
