$(function () {
    var options = {
        beforeSubmit: showRequest,  // pre-submit callback 
        success: showResponse  // post-submit callback 
    };

    // bind form using 'ajaxForm' 
    $('#loginForm').ajaxForm(options);
});

// pre-submit callback 
function showRequest(formData, jqForm, options) {
    if (!formData.email) {
        alert("Missing email");
        return false;
    }
    if (!formData.password) {
        alert("Missing password");
        return false;
    }
    return true;
}

// post-submit callback 
function showResponse(responseText, statusText, xhr, $form) {
    alert('status: ' + statusText + '\n\nresponseText: \n' + responseText +
        '\n\nThe output div should have already been updated with the responseText.');
}