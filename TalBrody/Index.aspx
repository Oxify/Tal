<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Oxify.Master" CodeBehind="Index.aspx.cs" Inherits="TalBrody.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


	<div style="margin: 0px auto; min-height: 1000px; width: 1002px; max-width: 1002px; padding-left: 12px; padding-right: 12px;">

		<div style="text-align: center;">
			<h1 style="font-weight: bold; font-family: Arial, Helvetica, sans-serif">some stafe here 
			</h1>
			<br />
		</div>
		<div style="width: 500px; height: 400px">
			<asp:Image ID="Image1" Style="width: 500px; height: 400px" ImageUrl="http://imageshack.com/a/img908/6725/Lt4oMO.jpg" runat="server" />

		</div>
		<div>
			<asp:Repeater ID="rpt_Project" runat="server" OnItemDataBound="rpt_Project_ItemDataBound">
				<ItemTemplate>
					<div style="background-color: #E2E2E2; display: inline-block;">
						<div style="background-color: white; padding: 15px">
							<asp:HyperLink ID="HypProjectLink" runat="server">
								<h2>
									<asp:Label ID="LblProjectName" runat="server" Text="Label"></asp:Label></h2>
								<br />
								<h3>
									<asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label></h3>
							</asp:HyperLink>
						</div>
					</div>
				</ItemTemplate>
			</asp:Repeater>
		</div>

	</div>
</asp:Content>
