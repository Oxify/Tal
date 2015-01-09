<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Brody.aspx.cs" Inherits="fblogin.Brody" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Tal Brody - The Ambassador - Oxify</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<div style="text-align: center; width: 1008px; margin: 0px auto">
				This is the header<br />
				We will have here the logo and stuff 
    
			</div>
			<hr />

		</div>
		<div style="margin: 0px auto; min-height: 1000px; width: 1002px; max-width: 1002px; padding-left: 12px; padding-right: 12px;">
			<div style="text-align: center;">
				<h1 style="font-weight: bold; font-family: Arial, Helvetica, sans-serif">Tal Brody - The Ambassador
				</h1>
				<br />
			</div>
			<div>
				<div style="width: 750px">
					<iframe width="620" height="413" src="//www.youtube.com/embed/VEm1rDbwp9Y" frameborder="0" allowfullscreen></iframe>

					<br />
				</div>
				<div style="float: right; margin-top: -417px; margin-right: -120px; background-color: #E2E2E2">
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
									<h2>Perk #<asp:Label ID="lblPerkId" runat="server" Text="Label"></asp:Label>: <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label></h2> <br />
									<h3>
										<asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label></h3><br />
									<h4>Reach <asp:Label ID="lblCost" runat="server" Text="Label"></asp:Label> credits to get this perk!</h4>
									<br />
									<br />
								</div>
							</ItemTemplate>
							<FooterTemplate></FooterTemplate>
						</asp:Repeater>
						<div style="background-color: white; padding: 15px">
							<br />
							<br />
							<h2>Perk #1: Get early access</h2>
							<h4>Reach 10 credits to get this perk!</h4>
							<br />
							<br />
						</div>
						<br />
						<div style="background-color: white; padding: 15px">
							<br />
							<br />
							<h2>Perk #2: Thank you email</h2>
							<h4>Reach 25 credits to get this perk!</h4>
							<br />
							<br />
						</div>
						<br />
						<div style="background-color: white; padding: 15px">
							<br />
							<br />
							<h2>Perk #3: Personal autograph on the book</h2>
							<h4>Reach 50 credits to get this perk!</h4>
							<br />
							<br />
						</div>
						<br />
						<div style="background-color: white; padding: 15px">
							<br />
							<br />
							<h2>Perk #4: Invitation to party</h2>
							<h4>Reach 150 credits to get this perk!</h4>
							<br />
							<br />
						</div>
					</div>
				</div>
			</div>
		</div>
		<footer>
			<br />
			<br />
			<br />
			<hr />
			<div style="text-align: center; width: 1008px; margin: 0px auto">
				This is the footer<br />
				We will have here important links and stuff 
			</div>
		</footer>

	</form>
</body>
</html>
