
function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function isValidEmailAddress(emailAddress) {
    // var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
    var pattern = new RegExp("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
    return pattern.test(emailAddress);
};

function checkEmailOrPhone(Email) {
    return (Email == '' || Email == 'Your Email or Phone');
}

function checkPassword(Password) {
    return (Password == '' || Password == 'Your Password');
}

function checkEmail(Email) {
    return (Email == '' || Email == 'Your Email');
}

function checkPhone(Phone) {
    return (Phone == '' || Phone == 'Your Phone');
}

function limitChars(textid, limit) {
    var text = $('#' + textid).val();
    var textlength = text.length;
    if (textlength >= limit) {
        return true;
    }
    else {
        //alert('You cannot write more then ' + limit + ' characters!');
        $('#' + textid).val(text.substr(0, limit));
        return false;
    }
}

function createCookie(name, value, expires, path, domain) {
    var cookie = name + "=" + encodeURI(value) + ";";

    if (expires) {
        // If it's a date
        if (expires instanceof Date) {
            // If it isn't a valid date
            if (isNaN(expires.getTime()))
                expires = new Date();
        }
        else
            expires = new Date(new Date().getTime() + parseInt(expires) * 1000 * 60 * 60 * 24);

        cookie += "expires=" + expires.toGMTString() + ";";
    }

    if (path)
        cookie += "path=" + path + ";";
    if (domain)
        cookie += "domain=" + domain + ";";

    document.cookie = cookie;
}

function getCookie(cName) {
    if (document.cookie.length > 0) {
        var cStart = document.cookie.indexOf(cName + "=");
        if (cStart != -1) {
            cStart = cStart + cName.length + 1;
            var cEnd = document.cookie.indexOf(";", cStart);
            if (cEnd == -1) {
                cEnd = document.cookie.length;
            }
            return unescape(document.cookie.substring(cStart, cEnd));
        }
    }
    return null;
}

function deleteCookie2(name, path, domain) {
    // If the cookie exists
    if (getCookie(name))
        createCookie(name, "", -1, path, domain);
}

function deleteCookie(name, path, domain) {
    if (getCookie(name)) {
        document.cookie = name + "=" +
          ((path) ? ";path=" + path : "") +
          ((domain) ? ";domain=" + domain : "") +
          ";expires=Thu, 01 Jan 1970 00:00:01 GMT";
    }
}


function CreateCookieWithId(id) {
    var existing = getCookie("OxifyId");
    if (existing == id) {
        return;
    }
    if (existing != id) {
        deleteCookie("OxifyId");
    }

    createCookie("OxifyId", id, 30);

}

function PopupWindow() {
    var url = this.attributes['data-target'].value;
    window.open(url, "myWindow", "status = 1, height = 360, width = 500, resizable = 0");
}

//var applyMapContainerHeight = function () {
//   // debugger;
//    var height = $(window).height();
//    //        $("#map-container").height(height);
//    //$(".full-height-div").each(function () {
//    //    this.height = height;
//    //});

//    var elements = $(".full-height-div");
//    for (var i = 0; i < elements.length; i++) {
//        elements[i].height = height;
//    }
//};
$(document).ready(function () {

    var elements = document.getElementsByClassName('Popup-Link');
    for (var i = 0; i < elements.length; i++) {
        elements[i].onclick = PopupWindow;
    }

    //applyMapContainerHeight();


});

//$(window).resize(function () {

//    applyMapContainerHeight();
//});
