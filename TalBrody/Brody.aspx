<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Oxify.Master" CodeBehind="Brody.aspx.cs" Inherits="fblogin.Brody" %>

<%@ Register Src="~/UserControl/LogInControle.ascx" TagPrefix="uc1" TagName="LogInControle" %>
<%@ Register Src="~/UserControl/RegisterControl.ascx" TagPrefix="uc1" TagName="RegisterControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function() {
            $("#ContentPlaceHolder1_registerButton").click(function () {
                console.log("Clicked");
                $.post("Login/Register", {
                    email: $("#ContentPlaceHolder1_email").val()
                }, function() {
                    console.log("Success1");
                }).done(function() {
                    console.log("Second success (returned from server?)");
                }).fail(function() {
                    console.log("Post fail");
                });
                return false;
            });
        });
        
    </script>


	<link href="Css/Brody.css" rel="stylesheet" />
	<div style="margin: 0px auto; min-height: 1000px; width: 1002px; max-width: 1002px; padding-left: 12px; padding-right: 12px;">
		<div style="text-align: center;">
			<h1 style="font-weight: bold; font-family: Arial, Helvetica, sans-serif">Tal Brody - The Ambassador
			</h1>
			<br />
		</div>
		<div>
		    <div id="realleftcolumn">
		        <label for="email">Enter your email to join</label>
	            <input placeholder="you@email.com" id="email" runat="server" />
                <button id="registerButton" runat="server" text="Register">Submit</button>
<%--                <uc1:RegisterControl runat="server" ID="LogInControle" />--%>
            </div>
			<div style="width: 750px">
				<iframe width="620" height="413" src="//www.youtube.com/embed/VEm1rDbwp9Y" frameborder="0" allowfullscreen></iframe>

				<br />
			</div>
			<div style="width: 300px; margin-top: -417px; margin-left: 700px; background-color: #E2E2E2">
				<div style="margin: 0px auto; padding: 15px">
					<div style="background-color: white; padding: 15px">
						<br />
						<h2>Statistics comes here</h2>
						<br />
						<h2>Supporters:
                                <asp:Label ID="LblSupporters" runat="server" Text="Label"></asp:Label>
						</h2>
						<br />
						<br />
					</div>
					<br />
					<div style="background-color: white; padding: 15px">
						<br />
						<br />
						<h2>Information about the maker comes here</h2>
						<br />
						<br />
					</div>
					<br />
					<asp:Repeater ID="rpt_perks" runat="server" OnItemDataBound="rpt_perks_ItemDataBound">
						<HeaderTemplate></HeaderTemplate>
						<ItemTemplate>
							<div style="background-color: white; padding: 15px">
								<br />
								<br />
								<h2>Perk #<asp:Label ID="lblPerkId" runat="server" Text="Label"></asp:Label>:
									<asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label></h2>
								<br />
								<h3>
									<asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label></h3>
								<br />
								<h4>Reach
									<asp:Label ID="lblCost" runat="server" Text="Label"></asp:Label>
									credits to get this perk!</h4>
								<br />
								<br />
							</div>
							<br />
						</ItemTemplate>
						<FooterTemplate></FooterTemplate>
					</asp:Repeater>
				</div>
			</div>
		</div>
	</div>

</asp:Content>



