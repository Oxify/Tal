


var FacebookStatus;
var FacebookToken;
var Platform;
var Token;


function ShowMessage(message) {
    document.getElementById('clientsidelabel').innerHTML = message;
    document.getElementById('clientsidelabel').style.display = "block";

    document.getElementById('clientsidelabel2').innerHTML = message;
    document.getElementById('clientsidelabel2').style.display = "block";

}

function HideMessage() {
    document.getElementById('clientsidelabel').style.display = "none";
    document.getElementById('clientsidelabel2').style.display = "none";
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



function FacebookRegister(e) {
    HideMessage();
    Platform = "FB";
    Token = FacebookToken;
    if (FacebookStatus == 'connected') {
        RegisterSocial(Platform, Token, "");
    } else {

        FB.login(FacebookRegisterResult, {
            scope: 'public_profile, email, user_friends', return_scopes: 'true'
        }); //, user_birthday, user_location TODO after we request permissions

    }
    e.preventDefault();
    return false;
}

function LoginUsingFacebook(e) {
    HideMessage();
    //debugger;
    Platform = "FB";
    Token = FacebookToken;
    if (FacebookStatus == 'connected') {
        LoginSocial(Platform, Token);
    } else {

        FB.login(FacebookLoginResult, {
            scope: 'public_profile, email, user_friends', return_scopes: 'true'
        }); //, user_birthday, user_location TODO after we request permissions

    }
    e.preventDefault();
    return false;
}

function FacebookLoginResult(response) {
    if (response.status === 'connected') {
        // Logged into your app and Facebook.
        var elem = document.getElementById("txtEmail").value;

        LoginSocial("FB", response.authResponse.accessToken);

    } else if (response.status === 'not_authorized') {
        // The person is logged into Facebook, but not your app.
        ShowMessage("הרשמה כרוכה באישור האפליקציה של Oxify בפייסבוק");
    } else {
        // The person is not logged into Facebook, so we're not sure if
        // they are logged into this app or not.
    }

    return false;
}

function FacebookRegisterResult(response) {
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

            if (response.d.NextStep == 1) {
                CreateCookieWithId(response.d.UserId);
                window.location.href = "/p/m1fj/toys/share";
                // i close it for not do endless loops
                //window.location.reload(); // refreashg
            }
            else if (response.d.NextStep == -1)// missing email 
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



function RegisterEmail(name, password, email) {
    if (email == null) {
        email = "";
    }
    if (password == null) {
        password = "";

    }
    if (name == null) {
        name = "";
    }
    var params = "{'name':'" + name + "', 'password':'" + password + "' ,'email':'" + email + "'}";


    $.ajax({
        type: "POST",
        url: "/Ajax.aspx/EMailRegister",
        async: false,
        data: params,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.NextStep == 0)// msg 
            {
                ShowMessage(response.d.Message);
            } else if (response.d.NextStep == 1)
            {
                CreateCookieWithId(response.d.UserId);
                window.location.href = "/p/m1fj/toys/share";
            }

        },
        failure: function (msg) {
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });

}



function LoginSocial(platform, token) {

    var params = "{'platform':'" + platform + "', 'token':'" + token + "'}";

    $.ajax({
        type: "POST",
        url: "/Ajax.aspx/SocialLogin",
        async: false,
        data: params,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d == 0) {

                // TODO report error to user
                ShowMessage("משתמש לא מוכר");

            } else {
                CreateCookieWithId(response.d);
                // i close it for not do endless loops
                window.location.reload(); // refreashg
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
    e.preventDefault();

    var elem = document.getElementById("txtEmail").value;
    if (elem.indexOf('@') > 0) {
        RegisterSocial(Platform, Token, elem);
    } else {
        ShowMessage("אנא הכנס כתובת אימייל תקינה על מנת להמשיך");
    }
    return false;
}

function LoginWithEmail(e) {
    HideMessage();
    e.preventDefault();
    var email = document.getElementById("EmailLogin").value;
    var password = document.getElementById("PasswordLogin").value;
    CheckLogInLocal(email, password);

}

function CheckLogInLocal(email, password) {
    if (email == "") //)|| pas == "")
    {
        ShowMessage("אנא הכנס אימייל");
        return;
    }
    if (password == "") {
        ShowMessage("אנא הכנס סיסמא");
        return;
    }
    var params = "{'UserName':'" + email + "','Password':'" + password + "'}";

    $.ajax({
        type: "POST",
        url: "/Ajax.aspx/LogInCheck",
        async: false,
        data: params,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            if (response.d == 0) {
                ShowMessage("שם משתמש או סיסמא שגויים");

            } else {
                CreateCookieWithId(response.d);
                // i close it for not do endless loops
                window.location.reload(); // refreashg

            }
            
        },
        failure: function (msg) {
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
}
function StartEmailRegistration(e) {
    e.preventDefault();
    HideMessage();
    var name = document.getElementById("displayName").value;
    var password = document.getElementById("RegPassword").value;
    var email = document.getElementById("emailreg").value;
    if (email.indexOf('@') > 0) {
        RegisterEmail(name, password, email);
    } else {
        ShowMessage("אנא הכנס כתובת אימייל תקינה");
    }
    return false;


}
function LogOutSession() {

    $.ajax({
        type: "POST",
        url: "/Ajax.aspx/SessionLogout",
        async: false,
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d == 1) {
                deleteCookie("OxifyId"); // delete cooke
                deleteCookie2("OxifyId"); // delete cooke
                var test = getCookie("OxifyId");
                window.location.reload(); // refrash page
            }

        },
        failure: function (msg) {
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });

}



$('document').ready(function () {
    //onclick="FaceboookLogin(this); return false; "

    //var elem = $("#AddEmailButton");
    //elem.click(function(e) {
    //    debugger;
    //    SocialLoginWithEmail(e);
    //});

    $("#EmailRegistration").click(function (e) {
        StartEmailRegistration(e);
    });

    $("#EmailRegBack").click(function (e) {
        InitilizeRegistration();
        e.preventDefault();
        return false;
    });

    $("#AddEmailButton").click(function (e) {
        SocialLoginWithEmail(e);
    });

    $("#FacebookRegisterButton").click(function (e) {
        FacebookRegister(e);
    });


    $("#FacebookLoginButton").click(function (e) {
        LoginUsingFacebook(e);
    });

    $("#EMailLoginButton").click(function (e) {
        LoginWithEmail(e);
    });

    var elem = document.getElementById("FacebookRegisterButton");
    var Facebookid = elem.attributes['data-facebook-id'].value;
    FB.init({
        appId: Facebookid
    });

    FB.getLoginStatus(updateStatusCallback);

});