$(function () {
    $("#ContentPlaceHolder1_registerButton").click(function () {
        console.log("Clicked");
        $.post("/Login/RegisterOrLogin", {
            email: $("#ContentPlaceHolder1_email").val()
        }, function () {
            console.log("Success1");
        }).done(function (data) {
            console.log("Second success (returned from server?)");
            if (!data.success) {
                alert("Failure to create account: " + data.error);
                return;
            }

            if (data.redirectTo != "") {
                window.location = data.redirectTo;
                return;
            }

            console.log("Nowhere to redirect to?");
        }).fail(function () {
            console.log("Post fail");
        });
        return false;
    });
});
