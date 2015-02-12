﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Oxify.Master" CodeBehind="Cover.aspx.cs" Inherits="TalBrody.Cover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
	function ShowRegister() {

		var ProjectId = 1;

		var href = "Register.aspx?ProjectId=" + ProjectId;

		var txtSaveClickedHidden = '';
		var a = $(".BtnRegister").val;
		$(".BtnRegister").fancybox(
		{
			maxWidth: 516,
			maxHeight: 520,
			fitToView: false,
			width: '80%',
			height: '95%',
			autoSize: false,
			closeClick: false,
			openEffect: 'none',
			closeEffect: 'none',
			nextEffect: 'fade',
			prevEffect: 'fade',
			'href': href,
			'type': 'iframe',

			//Change title position and overlay color
			helpers:
			{
				title:
				{
					type: 'inside',
					position: 'top',
					background: '#032f4a',
					color: '#FFF'
				}
			},
			beforeClose: function () {
				//txtSaveClickedHidden = $('.fancybox-iframe').contents().find("#txtSaveClickedHidden").val();
			},
			afterClose: function () {
				//if (true) {
				//parent.location.reload(true);
				//}
			}
		});

	}
</script>
	<script type="text/javascript" src="JavaScript/Cover.js"> </script>
	<link href="Css/Cover.css" rel="stylesheet" />
	<div class="page-wrapper" id="firstpage" runat="server">
		<div class="page-content">
			<div class="first-page">
				<div class="Title">"השגריר"</div>
				<div class="SubTitle">ספרו האוטוביוגרפי של טל ברודי</div>
				<hr style="width: 900px" />
				<div class="Description">בקרוב יתחיל הקמפיין לגיוס התקציב הנחוץ להפקת ספרו האוטוביוגרפי של טל ברודי.
					<br />
					<b>הירשמו ותהיה הראשונים לדעת על השקת הקמפיין.</b><br />
					לאחר שנרשמתם, הפיצו את הקמפיין ותצברו 2 ש"ח על כל חבר שנרשם בזכותכם<br />
					לפרוייקט, אותם תוכלו לממש בקמפיין.</div>
				<a class="flat-button BtnRegister fancybox.iframe" id="BtnRegister" onclick="ShowRegister()">להרשמה</a><br />
			</div>
			<div class="scroll-button-wrapper">	
				<a href="#" class='ScrollButton' id="ScrollDown" data-goto="secondpage"></a>
			</div>
		</div>

	</div>
	<div class="page-wrapper">
		<div class="page-content" id="secondpage">
			<div class="additional-page">
				עוד המון תוכן על טל ברודי
                <br />
				גם תמונות וכו'
			</div>
		</div>
	</div>
	<div class="page-wrapper">
		<div class="page-content" id="thirdpage">
			<div class="additional-page">
				עוד המון תוכן על טל ברודי
                <br />
				גם תמונות וכו'
			</div>
		</div>
	</div>

</asp:Content>
