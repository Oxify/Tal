<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LogInControle.ascx.cs" Inherits="TalBrody.UserControl.LogInControle" %>

<%@ Register TagPrefix="rp" Namespace="DotNetOpenAuth.OpenId.RelyingParty" Assembly="DotNetOpenAuth.OpenId.RelyingParty.UI, Version=4.3.0.0, Culture=neutral, PublicKeyToken=2780ccd10d57b246" %>


<script type="text/javascript">

    $(document).ready(function () {
        $("#BtnLogin").click(function () {
            CheckLogiN();
        });
       
    });


    function CheckLogiN() {
        var usernam = $('#TxtUserName').val();
        var pas = $('#TxtPassword').val();
        $('#UserReq').hide();
        $('#PassReq').hide();
        $('#LblMessage').hide();
        if (usernam == "") //)|| pas == "")
        {
            $('#UserReq').show();
            return;
        }
        if (pas == "")
        {
            $('#PassReq').show();
            return;
        }
        var params = "{'UserName':'" + usernam + "','Password':'" + pas + "'}";

        $.ajax({
            type: "POST",
            url: "/Ajax.aspx/LogInCheck",
            async: false,
            data: params,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
    
                if (response.d == "1") {
                    // i close it for not do endless loops
                    window.location.reload(); // refreashg
                }
                if(response.d == "0")
                {
                    $('#LblMessage').show();

                }
            },
            failure: function (msg) {
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });
    }

</script>

<div>
    <div>

        <br />
        <br />
        <table id="LogInControle_Login1" style="border: 1px solid rgb(181, 199, 222); border-collapse: collapse; background-color: rgb(239, 243, 251);" cellspacing="0" cellpadding="4">
            <tbody>
                <tr>
                    <td>
                        <table style="width: 239px; height: 155px; color: rgb(51, 51, 51); font-family: Verdana; font-size: 0.8em;" cellpadding="0">
                            <tbody>
                                <tr>
                                    <td align="center" style="color: white; font-size: 0.9em; font-weight: bold; background-color: rgb(80, 124, 209);" colspan="2">Log In</td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <label for="LogInControle_Login1_UserName">User Name:</label></td>
                                    <td>
                                        <input id="TxtUserName" style="font-size: 0.8em;" type="text"><label title="User Name is required." id="UserReq" style="display:none ;">*</label></td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <label for="LogInControle_Login1_Password">Password:</label></td>
                                    <td>
                                        <input id="TxtPassword" style="font-size: 0.8em;" type="password"><label title="Password is required." id="PassReq" style="display: none;">*</label></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <label id="LblMessage" style="display: none;color:red" for="LogInControle_Login1_RememberMe">User Name Or Password incurect</label></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <input id="BtnLogin" style="border: 1px solid rgb(80, 124, 209); color: rgb(40, 78, 152); font-family: Verdana; font-size: 0.8em; background-color: white;" type="submit" value="Log In"></td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
        <br />
        <br />
    </div>
</div>
<!--
<table id="LogInControle_Login1" style="border: 1px solid rgb(181, 199, 222); border-collapse: collapse; background-color: rgb(239, 243, 251);" cellspacing="0" cellpadding="4">
	<tbody><tr>
		<td><table style="width: 239px; height: 155px; color: rgb(51, 51, 51); font-family: Verdana; font-size: 0.8em;" cellpadding="0">
			<tbody><tr>
				<td align="center" style="color: white; font-size: 0.9em; font-weight: bold; background-color: rgb(80, 124, 209);" colspan="2">Log In</td>
			</tr><tr>
				<td align="right"><label for="LogInControle_Login1_UserName">User Name:</label></td><td><input name="ctl00$LogInControle$Login1$UserName" id="LogInControle_Login1_UserName" style="font-size: 0.8em;" type="text"><span title="User Name is required." id="LogInControle_Login1_UserNameRequired" style="visibility: hidden;">*</span></td>
			</tr><tr>
				<td align="right"><label for="LogInControle_Login1_Password">Password:</label></td><td><input name="ctl00$LogInControle$Login1$Password" id="LogInControle_Login1_Password" style="font-size: 0.8em;" type="password"><span title="Password is required." id="LogInControle_Login1_PasswordRequired" style="visibility: hidden;">*</span></td>
			</tr><tr>
				<td colspan="2"><input name="ctl00$LogInControle$Login1$RememberMe" id="LogInControle_Login1_RememberMe" type="checkbox"><label for="LogInControle_Login1_RememberMe">Remember me next time.</label></td>
			</tr><tr>
				<td align="right" colspan="2"><input name="ctl00$LogInControle$Login1$LoginButton" id="LogInControle_Login1_LoginButton" style="border: 1px solid rgb(80, 124, 209); color: rgb(40, 78, 152); font-family: Verdana; font-size: 0.8em; background-color: white;" onclick='javascript: WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions("ctl00$LogInControle$Login1$LoginButton", "", true, "ctl00$LogInControle$Login1", "", false, false))' type="submit" value="Log In"></td>
			</tr>
		</tbody></table></td>
	</tr>
</tbody></table>
    -->



