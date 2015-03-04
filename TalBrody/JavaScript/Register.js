


var FacebookStatus;
var FacebookToken;
var Platform;
var Token;


function ShowMessage(message) {
    document.getElementById('clientsidelabel').innerHTML = message;
    document.getElementById('clientsidelabel').style.display = "block";

}

function HideMessage()
{
    document.getElementById('clientsidelabel').style.display = "none";
}
function updateStatusCallback(response) {

   // console.log('statusChangeCallback');
  //  console.log(response);
    // The response object is returned with a status field that lets the
    // app know the current login status of the person.
    // Full docs on the response object can be found in the documentation
    // for FB.getLoginStatus().
    FacebookStatus = response.status;

    if (response.status === 'connected') {
        FacebookToken = response.authResponse.accessToken;
        // Logged into your app and Facebook.
//              document.getElementById('status').innerHTML = 'Yay! logged in!';

    } else if (response.status === 'not_authorized') {
        // The person is logged into Facebook, but not your app.
 //           document.getElementById('status').innerHTML = 'Please log ' +
 //                 'into this app.';
    } else {
        // The person is not logged into Facebook, so we're not sure if
        // they are logged into this app or not.
//               document.getElementById('status').innerHTML = 'Please log ' +
 //                'into Facebook.';
    }
}



function FacebookLogin(e) {
    HideMessage();
    Platform = "FB";
    Token = FacebookToken;
    if (FacebookStatus == 'connected') {
        RegisterSocial(Platform, Token, "");
    } else {

        FB.login(FacebookLoginResult, {
            scope: 'public_profile, email, user_friends', return_scopes: 'true'
        }); //, user_birthday, user_location TODO after we request permissions
      
    }
    e.preventDefault();
    return false;
}



function FacebookLoginResult(response) {
//    console.log('FacebookLoginResult');
//    console.log(response);
    // The response object is returned with a status field that lets the
    // app know the current login status of the person.
    // Full docs on the response object can be found in the documentation
    // for FB.getLoginStatus().
    if (response.status === 'connected') {
        // Logged into your app and Facebook.
        var elem = document.getElementById("txtEmail").value;

        RegisterSocial("FB", response.authResponse.accessToken, elem);

    } else if (response.status === 'not_authorized') {
        // The person is logged into Facebook, but not your app.
        ShowMessage("הרשמה כרוכה באישור האפליקציה של Oxify בפייסבוק");
    } else {
        // The person is not logged into Facebook, so we're not sure if
        // they are logged into this app or not.
        document.getElementById('status').innerHTML = 'Please log ' +
            'into Facebook.';
    }

    return false;
}

function RegisterSocial(platform, token, email) {
    if (email == null) {
        email = "";
    }
    var params = "{'platform':'" + platform + "', 'token':'" + token + "' ,'email':'" + email + "'}";


    $.ajax({
        type: "POST",
        url: "/Ajax.aspx/SocialRegister",
        async: false,
        data: params,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            debugger;
            if (response.d.NextStep == 1) {
                window.top.location.href = '/Share.aspx';
                // i close it for not do endless loops
                //window.location.reload(); // refreashg
            }
            else if(response.d.NextStep == -1)// missing email 
            {
                ShowMissingEmail();
            }

        },
        failure: function (msg) {
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });

}


function SocialLoginWithEmail(e) {
    HideMessage();

    var elem = document.getElementById("txtEmail").value;
    if (elem.indexOf('@') > 0) {
        RegisterSocial(platform, Token, elem);
    } else {
        ShowMessage("אנא הכנס כתובת אימייל תקינה על מנת להמשיך");
    }
    e.preventDefault();
    return false;
}


$('document').ready(function () {
 
    //onclick="FaceboookLogin(this); return false; "
    $("#FacebookButton").click(function (e) {
        FacebookLogin(e);
    });
    $("#AddEmailButton").click(function (e) {
        SocialLoginWithEmail(e);
    });

    var elem = document.getElementById("FacebookButton");
    var Facebookid = elem.attributes['data-facebook-id'].value;
    FB.init({
        appId: Facebookid
    });

    FB.getLoginStatus(updateStatusCallback);

});