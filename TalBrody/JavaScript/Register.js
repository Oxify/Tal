
var FacebookStatus;
var FacebookToken;

function updateStatusCallback(response) {

 //   debugger;

    console.log('statusChangeCallback');
    console.log(response);
    // The response object is returned with a status field that lets the
    // app know the current login status of the person.
    // Full docs on the response object can be found in the documentation
    // for FB.getLoginStatus().
    FacebookStatus = response.status;

    if (response.status === 'connected') {
        FacebookToken = response.authResponse.accessToken;
        // Logged into your app and Facebook.
        //      document.getElementById('status').innerHTML = 'Yay! logged in!';

    } else if (response.status === 'not_authorized') {
        // The person is logged into Facebook, but not your app.
        //    document.getElementById('status').innerHTML = 'Please log ' +
        //          'into this app.';
    } else {
        // The person is not logged into Facebook, so we're not sure if
        // they are logged into this app or not.
        //       document.getElementById('status').innerHTML = 'Please log ' +
        //         'into Facebook.';
    }
}

$('document').ready(function () {
    //    $.ajaxSetup({ cache: true });
    //  $.getScript('https://connect.facebook.net/en_UK/all.js', function () {

    FB.init({
        appId: '1423139441310101',
    });
    //$('#loginbutton,#feedbutton').removeAttr('disabled');
    FB.getLoginStatus(updateStatusCallback);
    //});
});

function FaceboookLogin() {
    debugger;

    if (FacebookStatus == 'connected') {
        Register("FB", FacebookToken);
    } else {
        FB.login(FacebookLoginResult, { scope: 'public_profile, email, user_friends, user_birthday, user_location' });
     }
    return false;
}

function FacebookLoginResult(response) {
    
    console.log('FacebookLoginResult');
    console.log(response);
    // The response object is returned with a status field that lets the
    // app know the current login status of the person.
    // Full docs on the response object can be found in the documentation
    // for FB.getLoginStatus().
    if (response.status === 'connected') {
        // Logged into your app and Facebook.
        document.getElementById('status').innerHTML = 'Yay! logged in!';
        Register("FB", response.authResponse.accessToken);

    } else if (response.status === 'not_authorized') {
        // The person is logged into Facebook, but not your app.
        document.getElementById('status').innerHTML = 'Please log ' +
            'into this app.';
    } else {
        // The person is not logged into Facebook, so we're not sure if
        // they are logged into this app or not.
        document.getElementById('status').innerHTML = 'Please log ' +
            'into Facebook.';
    }
  
    return false;
}

function Register(platform, token) {
    debugger;
    var params = "{'platform':'" + platform + "', 'token':'"+ token+ "'}";

    $.ajax({
        type: "POST",
        url: "Ajax.aspx/SocialRegister",
        async: false,
        data: params,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d == 1) {
                debugger;
                // i close it for not do endless loops
                //window.location.reload(); // refreashg
            }

        },
        failure: function (msg) {
            debugger;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            	debugger;
        }
    });

}
