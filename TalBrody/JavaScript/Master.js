

function ShowRegisterByEMail() {
    $('#RegisterStart').hide();
    $('#RegisterByEMail').show();
    $('#ResgisterMissingEMail').hide();

}

function InitilizeRegistration() {
    $('#RegisterStart').show();
    $('#RegisterByEMail').hide();
    $('#ResgisterMissingEMail').hide();
    $('#LblRegistrationMessage').hide();
    $('#clientsidelabel').hide();
}

function ShowMissingEmail() {
    $('#RegisterStart').hide();
    $('#RegisterByEMail').hide();
    $('#ResgisterMissingEMail').show();

}