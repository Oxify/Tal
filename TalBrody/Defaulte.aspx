<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Defaulte.aspx.cs" Inherits="Oxify.Defaulte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<script>
		// Load the SDK Asynchronously
		(function (d) {
			var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
			if (d.getElementById(id)) { return; }
			js = d.createElement('script'); js.id = id; js.async = true;
			js.src = "//connect.facebook.net/en_US/all.js";
			ref.parentNode.insertBefore(js, ref);
		}(document));

		// Init the SDK upon load
		window.fbAsyncInit = function () {
			FB.init({
				appId: '155578484623690', // Write your own application id
				channelUrl: '//' + window.location.hostname + '/channel', // Path to your Channel File
				scope: 'id,name,gender,user_birthday,email',
				status: true, // check login status
				cookie: true, // enable cookies to allow the server to access the session
				xfbml: true  // parse XFBML
			});
			// listen for and handle auth.statusChange events
			FB.Event.subscribe('auth.statusChange', function (response) {
				if (response.authResponse) {
					// user has auth'd your app and is logged into Facebook
					var uid = "http://graph.facebook.com/" + response.authResponse.userID + "/picture";
					FB.api('/me', function (me) {
						if (me.name) {
							document.getElementById('auth-displayname').innerHTML = me.name;
							document.getElementById('Email').innerHTML = me.email;
							document.getElementById('BD').innerHTML = me.birthday;
							document.getElementById('profileImg').src = uid;
							document.getElementById('Gender').innerHTML = me.gender;
						}
					})
					document.getElementById('auth-loggedout').style.display = 'none';
					document.getElementById('auth-loggedin').style.display = 'block';
				} else {
					// user has not auth'd your app, or is not logged into Facebook
					document.getElementById('auth-loggedout').style.display = 'block';
					document.getElementById('auth-loggedin').style.display = 'none';
				}
			});
			$("#auth-logoutlink").click(function () { FB.logout(function () { window.location.reload(); }); });
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<div style="height: 500px; margin-left: 23px;">
				<h1>Facebook Login Authentication Example</h1>
				<div id="auth-status">
					<div id="auth-loggedout">
						<div class="fb-login-button" autologoutlink="true" scope="email,user_checkins">
							Login with Facebook
						</div>
					</div>
					<div id="auth-loggedin" style="display: none">
						Hi, <span id="auth-displayname"></span>(<a href="#" id="auth-logoutlink">logout</a>)
                    <br />
						Email: <span id="Email"></span>
						<br />
						Ammar's Birthday <span id="BD"></span>
						<br />
						Gender :<span id="Gender"></span><br />
						<br />
						Profile Image:
                    <img id="profileImg" />
					</div>
				</div>
			</div>
		</div>
	</form>
</body>
</html>
