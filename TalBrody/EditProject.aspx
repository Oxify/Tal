<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Oxify.Master" CodeBehind="EditProject.aspx.cs" Inherits="TalBrody.EditProject" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div>
        <asp:Label ID="Label1" runat="server" Text="Followers"></asp:Label>
        <div>
            <asp:Chart ID="ChJoin" runat="server" Height="300px" Width="500px">
                <Series>
                    <asp:Series XValueMember="Days" IsValueShownAsLabel="true" YValueMembers="Hits"
                        Name="Series1" ChartType="Line" Color="#0033cc" IsVisibleInLegend="true" BorderWidth="1">
                    </asp:Series>

                </Series>
                <BorderSkin BackColor="Olive" BorderColor="Olive" SkinStyle="Emboss" />
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BorderWidth="0">
                        <AxisY Title="Join" Interval="Auto"></AxisY>
                        <AxisX Title="Days"></AxisX>
                        <Area3DStyle IsClustered="True" Enable3D="false"></Area3DStyle>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
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
